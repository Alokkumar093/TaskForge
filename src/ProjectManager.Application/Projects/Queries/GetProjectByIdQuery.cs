using MediatR;
using TaskForge.Application.Projects.DTOs;

namespace TaskForge.Application.Projects.Queries;

public sealed record GetProjectByIdQuery(Guid Id) : IRequest<ProjectDto?>;
