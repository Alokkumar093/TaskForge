using Microsoft.AspNetCore.SignalR;

namespace TaskForge.API.Hubs;

/// <summary>
/// Real-time updates for project dashboards (tasks moved, comments added, etc.).
/// </summary>
public sealed class ProjectHub : Hub
{
    public Task JoinProject(Guid projectId)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, ProjectGroup(projectId));
    }

    public Task LeaveProject(Guid projectId)
    {
        return Groups.RemoveFromGroupAsync(Context.ConnectionId, ProjectGroup(projectId));
    }

    public static string ProjectGroup(Guid projectId) => $"project:{projectId}";
}
