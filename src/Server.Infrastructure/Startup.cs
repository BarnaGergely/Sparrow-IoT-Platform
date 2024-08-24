using Microsoft.Extensions.DependencyInjection;
using Server.Application.Common.Interfaces;

namespace Server.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructureServices (this IServiceCollection services)
    {
        return services;
    }
    
    public static IServiceCollection AddInfrastructureDependencies (this IServiceCollection services)
    {
        services.AddDbContext<MeasurementsContext>();
        services.AddScoped<IMeasurementsRepository, MeasurementsRepository>();
        return services;
    }
}
