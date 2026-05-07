using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class MilestoneTask
{
    public Guid MilestoneId { get; set; }

    public Guid TaskId { get; set; }
}
