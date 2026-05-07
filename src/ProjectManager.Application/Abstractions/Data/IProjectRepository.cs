using TaskForge.Application.Projects.DTOs;

namespace TaskForge.Application.Abstractions.Data;

public interface IProjectRepository
{
    Task<ProjectDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Guid> AddAsync(string name, string? description, CancellationToken cancellationToken);
}
