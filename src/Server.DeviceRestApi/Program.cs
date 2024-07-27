// TODO: Violates Single Responsibility Principle

using Server.DeviceRestApi;
using Server.Application;
using Server.Infrastructure;
using DotNext;
using Server.Domain.Entities.ApiEntities;
using Server.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // TODO: CHeck in swaggler docs that is it required in production environment
builder.Services.AddSwaggerGen();
//builder.Services.AddProblemDetails(); // Add exception handling middleware

builder.Services
    .AddDeviceRestApi()
    .AddApplication()
    .AddInfrastructure();


var app = builder.Build();

//app.UseExceptionHandler(); // TODO: check how is it works

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// https://stackoverflow.com/questions/28329788/pass-json-with-multi-type-lists-to-web-api
app.MapPost("/api/devices/datas", (Sensor data) => {
    Results.Ok(data);
}) // TODO: https://blog.jetbrains.com/dotnet/2023/04/25/introduction-to-asp-net-core-minimal-apis/
    .WithName("AddSensorData")
    .WithDescription("Save sensor data on the server")
    .WithOpenApi();

app.MapGet("/api/devices/commands", () => "0")
    .WithName("GetDeviceCommands")
    .WithDescription("Get commands for a device")
    .WithOpenApi();
/*
Sensor sensor = new Sensor {
    Id = Guid.NewGuid(),
    Name = "Sensor 1",
    Description = "Description",
    Values = new List<SensorValue>{
        new SensorValue<int>{
            Id = 1,
            ValueTyped = 1
        },
        new SensorValue<string>{
            Id = 2,
            ValueTyped = "2"
        },
        new SensorValue<double>{
            Id = 3,
            ValueTyped = 3.0
        },
        new SensorValue<bool>{
            Id = 4,
            ValueTyped = true
        }
    }
};
*/

app.Run(); // TODO: Read port from configuration: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment
// TODO: HTTPS: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment