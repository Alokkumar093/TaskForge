using MediatR;

namespace TaskForge.Application.Tasks.Commands;

public sealed record CreateTaskCommand(Guid ProjectId, string Title, string? Description) : IRequest<Guid>;
