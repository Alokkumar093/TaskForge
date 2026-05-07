using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class Milestone
{
    public Guid Id { get; set; }

    public Guid? ProjectId { get; set; }

    public string? Title { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }
}
