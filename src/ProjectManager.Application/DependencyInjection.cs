using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskForge.Application.Common.Behaviours;

namespace TaskForge.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuditBehaviour<,>));

        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        return services;
    }
}
