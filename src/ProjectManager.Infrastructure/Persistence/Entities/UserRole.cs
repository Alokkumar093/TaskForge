using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class UserRole
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public int RoleId { get; set; }

    public Guid? OrgId { get; set; }

    public Guid? ProjectId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
