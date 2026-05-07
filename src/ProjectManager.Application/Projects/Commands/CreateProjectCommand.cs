using MediatR;

namespace TaskForge.Application.Projects.Commands;

public sealed record CreateProjectCommand(string Name, string? Description) : IRequest<Guid>;
