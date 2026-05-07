using System.Reflection;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskForge.Application.Abstractions.Services;

namespace TaskForge.Application.Common.Behaviours;

/// <summary>
/// Lightweight auditing/logging pipeline hook; extend here once entities track audit columns.
/// </summary>
public sealed class AuditBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ICurrentUserService _currentUser;
    private readonly ILogger<AuditBehaviour<TRequest, TResponse>> _logger;

    public AuditBehaviour(ICurrentUserService currentUser, ILogger<AuditBehaviour<TRequest, TResponse>> logger)
    {
        _currentUser = currentUser;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).GetTypeInfo().Name;
        var userId = _currentUser.UserId ?? "anonymous";

        _logger.LogDebug("Handling {Request} as {UserId}", requestName, userId);
        return await next();
    }
}
