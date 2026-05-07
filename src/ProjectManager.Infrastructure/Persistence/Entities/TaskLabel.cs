using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class TaskLabel
{
    public Guid TaskId { get; set; }

    public string Label { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
