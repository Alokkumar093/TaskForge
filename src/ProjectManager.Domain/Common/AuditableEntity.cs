namespace TaskForge.Domain.Common;

/// <summary>
/// Optional base for domain entities. After database-first scaffold you can inherit mapped entities from this
/// or merge these columns into generated partial classes.
/// </summary>
public abstract class AuditableEntity
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }
}
