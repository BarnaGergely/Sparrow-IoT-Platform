using Application.IotDevice.Measurements;
using Application.IotDevice.Measurements;
using Application.Web;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Startup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMeasurementsService, MeasurementsService>();
        return services;
    }

    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IMeasurementsMapper, MeasurementsMapper>();
        return services;
    }
}
