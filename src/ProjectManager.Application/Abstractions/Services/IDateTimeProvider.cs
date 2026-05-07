namespace TaskForge.Application.Abstractions.Services;

public interface IDateTimeProvider
{
    DateTimeOffset UtcNow { get; }
}
