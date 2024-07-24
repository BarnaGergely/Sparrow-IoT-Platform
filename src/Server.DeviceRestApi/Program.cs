// TODO: Violates Single Responsibility Principle

using Server.DeviceRestApi;
using Server.Application;
using Server.Infrastructure;
using Server.Domain.Entities;
using DotNext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // TODO: CHeck in swaggler docs that is it required in production environment
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails(); // Add exception handling middleware

builder.Services
    .AddDeviceRestApi()
    .AddApplication()
    .AddInfrastructure();


var app = builder.Build();

app.UseExceptionHandler(); // TODO: check how is it works

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/devices/datas", (SensorDataRequest data) => {
    Results.Ok(data);
}) // TODO: https://blog.jetbrains.com/dotnet/2023/04/25/introduction-to-asp-net-core-minimal-apis/
    .WithName("AddSensorData")
    .WithDescription("Save sensor data on the server")
    .WithOpenApi();

app.MapGet("/api/devices/commands", () => "0")
    .WithName("GetDeviceCommands")
    .WithDescription("Get commands for a device")
    .WithOpenApi();

app.Run(); // TODO: Read port from configuration: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment
// TODO: HTTPS: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment