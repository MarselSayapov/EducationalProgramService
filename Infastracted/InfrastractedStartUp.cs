using Domain.Entities;
using Domain.Interfaces;
using Infastracted.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infastracted;

public static class InfrastractedStartUp
{
    public static IServiceCollection TryAddInfastracted(this IServiceCollection services)
    {
        services.TryAddScoped<IRepository<EducationalProgram>, EducationalProgramRepository>();
        services.TryAddScoped<IRepository<EducationalModule>, EducationalModuleRepository>();
        return services;
    }
    
    public static IServiceCollection TryAddApplicationContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ProgramDbContext>(options =>
            options.UseSqlServer(connectionString));
        return services;
    }
}