using Application.IotDevice.Measurements;
using Application.IotDevice.Measurements;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Startup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IMeasurementsService, MeasurementsService>();
        services.AddScoped<IMeasurementsMapper, MeasurementsMapper>();
        return services;
    }
}
