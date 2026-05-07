using TaskForge.Application.Tasks.DTOs;

namespace TaskForge.Application.Abstractions.Data;

public interface ITaskRepository
{
    Task<TaskItemDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Guid> AddAsync(Guid projectId, string title, string? description, CancellationToken cancellationToken);
}
