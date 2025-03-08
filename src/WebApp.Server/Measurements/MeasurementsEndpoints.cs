using Application.IotDevice.Measurements;
using Application.Web;
using Domain.IotDevice.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Server.Measurements;

public static class MeasurementsEndpoints
{
    public static IEndpointRouteBuilder MapMeasurementsEndpoints(this IEndpointRouteBuilder group)
    {
        group.MapGet("/measurements", async (IWebRepository repository) =>
        {
            return await repository.Measurements.ToListAsync();
        })
        .WithName("GetAllMeasurements");

        group.MapGet("/measurements/{id}", async (IWebRepository repository, int id) =>
        {
            return await repository.Measurements.FindAsync(id)
                is Measurement measurement
                ? Results.Ok(measurement)
                : Results.NotFound();
        })
        .WithName("GetMeasurementById");

        group.MapGet("/measurements/sensor/{id}", async (IWebRepository repository, int id) =>
        {
            return await repository.Measurements.Where(m => m.SensorId == id).ToListAsync();
        });

        group.MapPost("/measurements", async (IWebRepository repository, Measurement measurement) =>
        {
            repository.Measurements.Add(measurement);
            await repository.SaveChangesAsync();
            return Results.Created($"/measurements/{measurement.Id}", measurement);
        });

        group.MapPut("/measurements/{id}", async (int id, Measurement measurement, IWebRepository repository) =>
        {
            var existingMeasurement = await repository.Measurements.FindAsync(id);
            if (existingMeasurement is null) return Results.NotFound();

            if (await repository.Sensors.FindAsync(measurement.SensorId) is Sensor sensor)
            {
                existingMeasurement.Value = measurement.Value;
                existingMeasurement.Sensor = sensor;
                existingMeasurement.MeasurementTime = measurement.MeasurementTime;
                existingMeasurement.ReceptionTime = measurement.ReceptionTime;
                existingMeasurement.Kind = measurement.Kind;

                await repository.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.BadRequest();
        });

        group.MapDelete("/measurements/{id}", async (IWebRepository repository, int id) =>
        {
            if (repository.Measurements.Find(id) is Measurement measurement)
            {
                repository.Measurements.Remove(measurement);
                await repository.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        });

        return group;
    }
}