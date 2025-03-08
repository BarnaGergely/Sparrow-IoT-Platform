using Microsoft.Extensions.DependencyInjection;
using Application.Common.Interfaces;
using Infrastructure.Common.Data;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IIotRepository, IotRepository>();
        return services;
    }
}
