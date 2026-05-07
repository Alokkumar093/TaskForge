using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskForge.Domain.Common;

namespace TaskForge.Infrastructure.Services;

/// <summary>
/// Stamps <see cref="AuditableEntity"/> rows on save. Works once scaffolded entities inherit or compose audit fields.
/// </summary>
public sealed class AuditInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        ApplyAudit(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        ApplyAudit(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    private static void ApplyAudit(DbContext? context)
    {
        if (context is null)
            return;

        var utc = DateTimeOffset.UtcNow;

        foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = utc;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = utc;
                    break;
                case EntityState.Detached:
                case EntityState.Unchanged:
                case EntityState.Deleted:
                default:
                    break;
            }
        }
    }
}
