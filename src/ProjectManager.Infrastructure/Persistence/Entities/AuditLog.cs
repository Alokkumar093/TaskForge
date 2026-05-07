using System;
using System.Collections.Generic;

namespace TaskForge.Infrastructure.Persistence.Entities;

public partial class AuditLog
{
    public long Id { get; set; }

    public string? EntityType { get; set; }

    public Guid? EntityId { get; set; }

    public string? Action { get; set; }

    public Guid? UserId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? Ipaddress { get; set; }

    public DateTime? Timestamp { get; set; }
}
