using MediatR;
using TaskForge.Application.Abstractions.Data;
using TaskForge.Application.Tasks.DTOs;

namespace TaskForge.Application.Tasks.Queries;

public sealed class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDto?>
{
    private readonly ITaskRepository _tasks;

    public GetTaskByIdHandler(ITaskRepository tasks)
    {
        _tasks = tasks;
    }

    public Task<TaskItemDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        return _tasks.GetByIdAsync(request.Id, cancellationToken);
    }
}
