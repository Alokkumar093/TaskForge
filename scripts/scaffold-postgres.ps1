# Run from repo root when PostgreSQL is reachable. Optionally set:
#   $env:TASKFORGE_PG_CONNECTION = 'Host=...;Port=5432;Database=...;Username=...;Password=...'
param(
    [Parameter(Mandatory = $false)]
    [string] $ConnectionString = $env:TASKFORGE_PG_CONNECTION
)

if ([string]::IsNullOrWhiteSpace($ConnectionString)) {
    Write-Error "Set environment variable TASKFORGE_PG_CONNECTION or pass -ConnectionString."
    exit 1
}

dotnet ef dbcontext scaffold $ConnectionString Npgsql.EntityFrameworkCore.PostgreSQL `
    --project src/ProjectManager.Infrastructure `
    --startup-project src/ProjectManager.API `
    --output-dir Persistence/Entities `
    --context-dir Persistence/Entities `
    --context TaskForgeDbContext `
    --namespace TaskForge.Infrastructure.Persistence.Entities `
    --suppress-on-configuring `
    --force