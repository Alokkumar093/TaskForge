using System.Text.Json;
using FluentValidation;
using TaskForge.Application.Common.Exceptions;

namespace TaskForge.API.Middleware;

public sealed class ExceptionMiddleware
{
    private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning(ex, "Validation failed");
            await WriteProblemAsync(context, StatusCodes.Status400BadRequest, "Validation failed", ex.Errors.Select(e => e.ErrorMessage).ToArray());
        }
        catch (PersistencePendingException ex)
        {
            _logger.LogWarning(ex, "Persistence not configured");
            await WriteProblemAsync(context, StatusCodes.Status503ServiceUnavailable, ex.Message, null);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            await WriteProblemAsync(
                context,
                StatusCodes.Status500InternalServerError,
                "An unexpected error occurred.",
                null);
        }
    }

    private static Task WriteProblemAsync(HttpContext context, int statusCode, string title, string[]? errors)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = statusCode;

        var payload = new ProblemPayload(title, errors);

        return context.Response.WriteAsync(JsonSerializer.Serialize(payload, JsonOptions));
    }

    private sealed record ProblemPayload(string Title, string[]? Errors);
}
