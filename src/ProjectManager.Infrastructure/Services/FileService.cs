using Microsoft.Extensions.Logging;
using TaskForge.Application.Abstractions.Services;

namespace TaskForge.Infrastructure.Services;

public sealed class FileService : IFileService
{
    private readonly ILogger<FileService> _logger;

    public FileService(ILogger<FileService> logger)
    {
        _logger = logger;
    }

    public Task<string> SaveBlobAsync(string suggestedFileName, Stream content, CancellationToken cancellationToken = default)
    {
        _logger.LogWarning("File storage not configured; returning placeholder path for {FileName}", suggestedFileName);
        _ = content;
        _ = cancellationToken;
        return Task.FromResult(Path.Combine("uploads", suggestedFileName));
    }
}
