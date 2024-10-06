using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Services;

public static class ServiceStartUp
{
    public static IServiceCollection TryAddService(this IServiceCollection services)
    {
        services.TryAddScoped<IModuleService, ModuleService>();
        services.TryAddScoped<IProgramService, ProgramService>();
        services.TryAddScoped<IInstituteService, InstituteService>();
        services.TryAddScoped<IHeadUserService, HeadService>();
        services.TryAddScoped<IIdentityService, IdentityService>();
        return services;
    }
}