using Application.Web;
using Domain.IotDevice.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Server;

public static class SensorsEndpoints
{
    public static IEndpointRouteBuilder MapSensorsEndpoints(this IEndpointRouteBuilder group)
    {
        group.MapGet("/sensors", async (IWebRepository repository) =>
        {
            return await repository.Sensors.ToListAsync();
        })
        .WithName("GetAllSensors");

        group.MapGet("/sensors/{id}", async (IWebRepository repository, int id) =>
        {
            return await repository.Sensors.FindAsync(id)
                is Sensor sensor
                ? Results.Ok(sensor)
                : Results.NotFound();
        })
        .WithName("GetSensorById");

        group.MapGet("/sensors/device/{id}", async (IWebRepository repository, int id) =>
        {
            return await repository.Sensors.Where(s => s.DeviceId == id).ToListAsync();
        })
        .WithName("GetSensorsByDevice");

        group.MapPost("/sensors", async (IWebRepository repository, Sensor sensor) =>
        {
            repository.Sensors.Add(sensor);
            await repository.SaveChangesAsync();
            return Results.Created($"/sensors/{sensor.Id}", sensor);
        });

        group.MapPut("/sensors/{id}", async (int id, Sensor sensor, IWebRepository repository) =>
        {
            var existingSensor = await repository.Sensors.FindAsync(id);
            if (existingSensor is null) return Results.NotFound();

            existingSensor.Name = sensor.Name;
            existingSensor.Kind = sensor.Kind;
            existingSensor.DeviceId = sensor.DeviceId;

            await repository.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/sensors/{id}", async (IWebRepository repository, int id) =>
        {
            if (repository.Sensors.Find(id) is Sensor sensor)
            {
                repository.Sensors.Remove(sensor);
                await repository.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        });

        return group;
    }
}