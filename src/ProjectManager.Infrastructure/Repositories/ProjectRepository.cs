using TaskForge.Application.Abstractions.Data;
using TaskForge.Application.Common.Exceptions;
using TaskForge.Application.Projects.DTOs;
using TaskForgeDbContext = TaskForge.Infrastructure.Persistence.Entities.TaskForgeDbContext;

namespace TaskForge.Infrastructure.Repositories;

public sealed class ProjectRepository : IProjectRepository
{
    private readonly TaskForgeDbContext _db;

    public ProjectRepository(TaskForgeDbContext db)
    {
        _db = db;
    }

    public Task<ProjectDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // Replace with projected query once scaffold adds DbSet<Project> (or equivalent).
        _ = id;
        _ = cancellationToken;
        return Task.FromResult<ProjectDto?>(null);
    }

    public Task<Guid> AddAsync(string name, string? description, CancellationToken cancellationToken)
    {
        _ = name;
        _ = description;
        _ = cancellationToken;
        _ = _db;
        throw new PersistencePendingException(
            "Project persistence is not wired yet. Scaffold entities from your database (database-first), add DbSet mappings, then implement AddAsync.");
    }
}
