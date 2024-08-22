using Server.Application.IotDevice.Measurements;
using Server.DeviceRestApi.Measurements.Entities;

namespace Server.DeviceRestApi.Measurements;

public static class MeasurementsEndpoints
{
    public static RouteGroupBuilder MapMeasurementsEndpoints(this RouteGroupBuilder group)
    {
        // Docs: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/route-handlers?view=aspnetcore-8.0#route-groups
        group.MapPost("/", (
            AddDeviceDataRequest data,
            IMeasurementsCommandHandler handler
            ) =>
            {
                var command = new AddMeasurementsCommand
                {
                    DeviceId = data.DeviceId,
                    MeasurementTime = data.MeasurementTime,
                    ReceptionTime = DateTime.Now,
                    Measurements = data.Measurements.Select(m => new MeasurementRaw
                    {
                        SensorId = m.SensorId,
                        Value = m.Value,
                        CreatedAt = m.CreatedAt
                    })
                };

                var result = handler.AddMeasurements(command);
                // TODO: change it to use different status codes
                if (!result.IsSuccessful)
                    return Results.BadRequest(result.Error.Message);

                return Results.Created();
            }) // TODO: https://blog.jetbrains.com/dotnet/2023/04/25/introduction-to-asp-net-core-minimal-apis/
                .WithName("AddSensorData")
                .WithDescription("Save sensor data on the server")
                .WithOpenApi();

        return group;
    }
}