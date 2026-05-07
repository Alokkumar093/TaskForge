namespace TaskForge.Application.Tasks.DTOs;

public sealed class TaskItemDto
{
    public Guid Id { get; init; }

    public Guid ProjectId { get; init; }

    public string Title { get; init; } = string.Empty;

    public string? Description { get; init; }
}
