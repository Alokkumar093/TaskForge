namespace TaskForge.Application.Abstractions.Services;

public interface ICurrentUserService
{
    string? UserId { get; }

    string? Email { get; }
}
