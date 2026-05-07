using Microsoft.Extensions.Logging;
using TaskForge.Application.Abstractions.Services;

namespace TaskForge.Infrastructure.Services;

public sealed class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> _logger;

    public NotificationService(ILogger<NotificationService> logger)
    {
        _logger = logger;
    }

    public Task NotifyProjectMembersAsync(Guid projectId, string message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Notification stub: Project={ProjectId} Message={Message}", projectId, message);
        return Task.CompletedTask;
    }
}
