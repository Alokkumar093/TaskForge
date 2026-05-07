using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class Attachment
{
    public Guid Id { get; set; }

    public string? EntityType { get; set; }

    public Guid? EntityId { get; set; }

    public string? FileName { get; set; }

    public long? FileSize { get; set; }

    public string? MimeType { get; set; }

    public string? BlobUrl { get; set; }

    public Guid? UploadedBy { get; set; }

    public DateTime? UploadedAt { get; set; }

    public bool? IsDeleted { get; set; }
}
