using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Services;

public static class ServiceStartUp
{
    public static IServiceCollection TryAddService(this IServiceCollection services)
    {
        services.TryAddScoped<IModuleService, ModuleService>();
        services.TryAddScoped<IProgramService, ProgramService>();
        
        return services;
    }
}