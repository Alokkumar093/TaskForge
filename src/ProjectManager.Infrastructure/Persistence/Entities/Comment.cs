using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class Comment
{
    public Guid Id { get; set; }

    public string? EntityType { get; set; }

    public Guid? EntityId { get; set; }

    public Guid? AuthorId { get; set; }

    public string? Content { get; set; }

    public Guid? ParentCommentId { get; set; }

    public string? MentionedUserIds { get; set; }

    public bool? IsEdited { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
