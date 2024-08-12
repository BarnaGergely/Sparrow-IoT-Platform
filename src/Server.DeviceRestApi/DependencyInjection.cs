using Microsoft.Extensions.DependencyInjection;
using Server.Application.Measurements;
using Server.DeviceRestApi.Measurements;

namespace Server.DeviceRestApi;

public static class DependencyInjection
{
    public static IServiceCollection AddDeviceRestApi (this IServiceCollection services)
    {
        services.AddScoped<IMeasurementsService, MeasurementsService>();
        services.AddScoped<IMeasurementsCommandHandler, MeasurementsCommandHandler>();
        return services;
    }
}
