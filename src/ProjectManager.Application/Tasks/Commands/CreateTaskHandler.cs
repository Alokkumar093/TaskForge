using MediatR;
using TaskForge.Application.Abstractions.Data;

namespace TaskForge.Application.Tasks.Commands;

public sealed class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly ITaskRepository _tasks;

    public CreateTaskHandler(ITaskRepository tasks)
    {
        _tasks = tasks;
    }

    public Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        return _tasks.AddAsync(request.ProjectId, request.Title, request.Description, cancellationToken);
    }
}
