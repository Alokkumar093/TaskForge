using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class Organization
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PlanType { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
