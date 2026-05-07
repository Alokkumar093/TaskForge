using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class Task
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public Guid? SprintId { get; set; }

    public Guid? ParentTaskId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public int? Priority { get; set; }

    public Guid? AssigneeId { get; set; }

    public Guid? ReporterId { get; set; }

    public DateOnly? DueDate { get; set; }

    public double? EstimatedHours { get; set; }

    public double? LoggedHours { get; set; }

    public int? Position { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Task> InverseParentTask { get; set; } = new List<Task>();

    public virtual Task? ParentTask { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<TaskLabel> TaskLabels { get; set; } = new List<TaskLabel>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
