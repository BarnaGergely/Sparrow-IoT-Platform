using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using IotRestApi.Measurements.Entities;
using Application.IotDevice.Measurements;

namespace IotRestApi.Measurements;

public static class MeasurementsEndpoints
{
    public static IEndpointRouteBuilder MapMeasurementsEndpoints(this IEndpointRouteBuilder group)
    {
        // Docs: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/route-handlers?view=aspnetcore-8.0#route-groups
        group.MapPost("measure", (
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
            .WithDescription("Save sensor data on the server");

        group.MapGet("measure", () =>
        {
            var deviceDataRequest = new AddDeviceDataRequest
            {
                DeviceId = 1,
                MeasurementTime = DateTime.Now,
                Measurements = new List<MeasurementInRequest>
                {
                    new MeasurementInRequest
                    {
                        SensorId = 1,
                        Value = 1.0,
                        CreatedAt = DateTime.Now
                    }
                }
            };
            return Results.Ok(deviceDataRequest);
        });

        return group;
    }
}