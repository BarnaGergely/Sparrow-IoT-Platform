using Application.IotDevice.Measurements;
using Application.Web;

namespace WebApp.Server.Measurements;

public static class MeasurementsEndpoints
{
    public static IEndpointRouteBuilder MapMeasurementsEndpoints(this IEndpointRouteBuilder group)
    {
        group.MapGet("measurements", (int deviceId, IWebRepository webRepository) =>
        {
            var measurements = webRepository.Measurements
                .Where(measurement => measurement.Sensor.DeviceId == deviceId);
            return measurements;

        });

        return group;
    }
}
