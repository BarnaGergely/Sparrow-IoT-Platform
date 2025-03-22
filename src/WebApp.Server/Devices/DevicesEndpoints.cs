using Application.Web;
using Domain.IotDevice.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Server.Devices;

public static class DevicesEndpoints
{
    internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public static IEndpointRouteBuilder MapDevicesEndpoints(this IEndpointRouteBuilder group)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        group.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast");

        group.MapGet("/devices", async (IWebRepository repository) =>
        {
            return await repository.Devices.ToListAsync();

        })
        .WithName("GetAllDevices");

        group.MapGet("/devices/{id}", async (IWebRepository repository, int id) =>
        {
            return await repository.Devices.FindAsync(id)
                is Device device
                ? Results.Ok(device)
                : Results.NotFound();
        })
        .WithName("GetDeviceById");

        group.MapPost("/devices", async (IWebRepository repository, Device device) =>
        {
            repository.Devices.Add(device);
            await repository.SaveChangesAsync();
            return Results.Created($"/devices/{device.Id}", device);
        });

        group.MapPut("/devices/{id}", async (int id, Device device, IWebRepository repository) =>
        {
            var existingDevice = await repository.Devices.FindAsync(id);
            if (existingDevice is null) return Results.NotFound();

            existingDevice.Name = device.Name;

            await repository.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/devices/{id}", async (IWebRepository repository, int id) =>
        {
            if (repository.Devices.Find(id) is Device device)
            {
                repository.Devices.Remove(device);
                await repository.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        });

        return group;
    }
}
