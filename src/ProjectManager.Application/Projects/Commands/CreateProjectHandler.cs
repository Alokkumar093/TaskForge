using MediatR;
using TaskForge.Application.Abstractions.Data;

namespace TaskForge.Application.Projects.Commands;

public sealed class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IProjectRepository _projects;

    public CreateProjectHandler(IProjectRepository projects)
    {
        _projects = projects;
    }

    public Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        return _projects.AddAsync(request.Name, request.Description, cancellationToken);
    }
}
