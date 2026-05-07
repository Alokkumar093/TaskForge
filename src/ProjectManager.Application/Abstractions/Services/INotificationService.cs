namespace TaskForge.Application.Abstractions.Services;

public interface INotificationService
{
    Task NotifyProjectMembersAsync(Guid projectId, string message, CancellationToken cancellationToken = default);
}
