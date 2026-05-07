using Microsoft.EntityFrameworkCore;
using Npgsql;
using TaskForge.API.Hubs;
using TaskForge.API.Middleware;
using TaskForge.API.Services;
using TaskForge.Application;
using TaskForge.Application.Abstractions.Services;
using TaskForge.Infrastructure;
using TaskForgeDbContext = TaskForge.Infrastructure.Persistence.Entities.TaskForgeDbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "TaskForge API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RateLimitMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskForge v1");
    });
    app.UseCors("DevelopmentFrontend");
}

app.UseHttpsRedirection();

app.MapControllers();
app.MapHub<ProjectHub>("/hubs/projects");

app.MapGet("/api/health/db", async (
    TaskForgeDbContext db,
    IHostEnvironment env,
    CancellationToken cancellationToken) =>
{
    try
    {
        await db.Database.ExecuteSqlRawAsync("SELECT 1", cancellationToken);

        var cx = db.Database.GetDbConnection();
        return Results.Ok(new { status = "connected", database = cx.Database, server = cx.DataSource });
    }
    catch (PostgresException ex)
    {
        var hint = ex.SqlState switch
        {
            "28P01" => "PostgreSQL authentication failed — verify Username/Password and pg_hba.conf.",
            "3D000" => "Database does not exist — create it or fix the Database name in the connection string.",
            "08006" => "Connection failure — check Host, Port, firewall, and that PostgreSQL accepts TCP connections.",
            _ => "See sqlState and message; common causes: auth, SSL mode, firewall, or wrong database name."
        };

        var payload = new
        {
            title = "Database connection failed",
            sqlState = ex.SqlState,
            message = ex.Message,
            hint,
            developerDetail = env.IsDevelopment() ? ex.ToString() : null
        };

        return Results.Json(payload, statusCode: StatusCodes.Status503ServiceUnavailable);
    }
    catch (Exception ex)
    {
        var detail = env.IsDevelopment()
            ? $"{ex.GetType().Name}: {ex.Message}"
            : "Unexpected error while connecting to the database.";

        return Results.Json(
            new { title = "Database connection failed", detail },
            statusCode: StatusCodes.Status503ServiceUnavailable);
    }
});

await app.RunAsync();
