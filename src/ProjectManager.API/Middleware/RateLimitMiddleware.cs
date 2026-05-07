namespace TaskForge.API.Middleware;

/// <summary>
/// Lightweight fixed-window limiter per client IP. For production prefer the built-in rate limiting middleware.
/// </summary>
public sealed class RateLimitMiddleware
{
    private readonly RequestDelegate _next;
    private readonly int _maxRequests;
    private readonly TimeSpan _window;
    private readonly Dictionary<string, WindowState> _state = new();
    private readonly object _gate = new();

    public RateLimitMiddleware(RequestDelegate next, int maxRequests = 200, int windowSeconds = 60)
    {
        _next = next;
        _maxRequests = maxRequests;
        _window = TimeSpan.FromSeconds(windowSeconds);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var key = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var now = DateTimeOffset.UtcNow;

        bool reject;

        lock (_gate)
        {
            reject = false;

            if (!_state.TryGetValue(key, out var w))
            {
                _state[key] = new WindowState(now, 1);
            }
            else if (now - w.Start > _window)
            {
                _state[key] = new WindowState(now, 1);
            }
            else if (w.Count >= _maxRequests)
            {
                reject = true;
            }
            else
            {
                _state[key] = w with { Count = w.Count + 1 };
            }
        }

        if (reject)
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            context.Response.Headers.RetryAfter = ((int)_window.TotalSeconds).ToString();
            return;
        }

        await _next(context);
    }

    private sealed record WindowState(DateTimeOffset Start, int Count);
}
