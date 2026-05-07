using MediatR;
using TaskForge.Application.Tasks.DTOs;

namespace TaskForge.Application.Tasks.Queries;

public sealed record GetTaskByIdQuery(Guid Id) : IRequest<TaskItemDto?>;
