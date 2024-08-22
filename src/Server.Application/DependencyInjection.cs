using Microsoft.Extensions.DependencyInjection;
using Server.Application.IotDevice.Measurements;

namespace Server.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddScoped<IMeasurementsService, MeasurementsService>();
        services.AddScoped<IMeasurementsMapper, MeasurementsMapper>();
        return services;
    }
}
