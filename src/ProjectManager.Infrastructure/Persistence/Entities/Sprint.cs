using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class Sprint
{
    public Guid Id { get; set; }

    public Guid? ProjectId { get; set; }

    public string? Name { get; set; }

    public string? Goal { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}
