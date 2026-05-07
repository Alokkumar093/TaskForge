using MediatR;
using TaskForge.Application.Abstractions.Data;
using TaskForge.Application.Projects.DTOs;

namespace TaskForge.Application.Projects.Queries;

public sealed class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, ProjectDto?>
{
    private readonly IProjectRepository _projects;

    public GetProjectByIdHandler(IProjectRepository projects)
    {
        _projects = projects;
    }

    public Task<ProjectDto?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        return _projects.GetByIdAsync(request.Id, cancellationToken);
    }
}
