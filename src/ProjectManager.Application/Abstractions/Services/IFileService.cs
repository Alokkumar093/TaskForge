namespace TaskForge.Application.Abstractions.Services;

public interface IFileService
{
    Task<string> SaveBlobAsync(string suggestedFileName, Stream content, CancellationToken cancellationToken = default);
}
