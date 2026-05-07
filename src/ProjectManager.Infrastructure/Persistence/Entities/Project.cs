using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class Project
{
    public Guid Id { get; set; }

    public Guid OrgId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsArchived { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Organization Org { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
