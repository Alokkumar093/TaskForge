using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskForge.Application.Abstractions.Data;
using TaskForge.Application.Abstractions.Services;
using TaskForgeDbContext = TaskForge.Infrastructure.Persistence.Entities.TaskForgeDbContext;
using TaskForge.Infrastructure.Repositories;
using TaskForge.Infrastructure.Services;

namespace TaskForge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string 'DefaultConnection' is missing or empty. " +
                "Set ConnectionStrings:DefaultConnection in appsettings.{Environment}.json, User Secrets (dotnet user-secrets), " +
                "or environment variable ConnectionStrings__DefaultConnection. " +
                "Ensure ASPNETCORE_ENVIRONMENT matches the file that holds your SQL connection (often Development).");
        }

        services.AddSingleton<AuditInterceptor>();

        services.AddDbContext<TaskForgeDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString);
            options.AddInterceptors(sp.GetRequiredService<AuditInterceptor>());
        });

        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<INotificationService, NotificationService>();

        return services;
    }
}
