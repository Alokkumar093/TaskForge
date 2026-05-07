using TaskForge.Application.Abstractions.Data;
using TaskForge.Application.Common.Exceptions;
using TaskForge.Application.Tasks.DTOs;
using TaskForgeDbContext = TaskForge.Infrastructure.Persistence.Entities.TaskForgeDbContext;

namespace TaskForge.Infrastructure.Repositories;

public sealed class TaskRepository : ITaskRepository
{
    private readonly TaskForgeDbContext _db;

    public TaskRepository(TaskForgeDbContext db)
    {
        _db = db;
    }

    public Task<TaskItemDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        _ = id;
        _ = cancellationToken;
        return Task.FromResult<TaskItemDto?>(null);
    }

    public Task<Guid> AddAsync(Guid projectId, string title, string? description, CancellationToken cancellationToken)
    {
        _ = projectId;
        _ = title;
        _ = description;
        _ = cancellationToken;
        _ = _db;
        throw new PersistencePendingException(
            "Task persistence is not wired yet. Scaffold entities from your database (database-first), add DbSet mappings, then implement AddAsync.");
    }
}
