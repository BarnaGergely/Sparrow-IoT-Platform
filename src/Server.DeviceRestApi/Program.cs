// TODO: Violates Single Responsibility Principle

using Server.DeviceRestApi;
using Server.Application;
using Server.Infrastructure;
using DotNext;
using Server.DeviceRestApi.Devices.Datas.Entities;
using Server.Domain.Entities;
using Server.Application.Devices.Sensors;
using Server.Application.Devices;
using Server.Application.Messures;
using System.Text.Json;


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

//builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.Converters.Add(new JsonSensorValueConverter()));

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
app.MapPost("/api/devices/datas", (
    AddDeviceDataRequest data,
    //SensorValueConverter sensorValueConverter,
    ISensorRepository sensorRepository,
    IDeviceRepository deviceRepository,
    IMessureRepository messureRepository
    ) =>
{
    DateTime createdAt = data.CreatedAt ?? DateTime.Now;


    // Validate device
    Result<Device> deviceResult = deviceRepository.GetDeviceAsync(data.DeviceId).Result;
    if (!deviceResult.IsSuccessful)
    {
        return Results.NotFound(deviceResult.Error.Message);
    }
    Device device = deviceResult.Value;

    List<SensorValue> sensorValues = [];
    
    // Convert SensorValue to SensorValue<T> and store in the sensorValues list
    foreach (var sensorValue in data.SensorValues)
    {
        // Validate sensor value
        Result<Sensor> sensorResult = sensorRepository.GetSensorAsync(sensorValue.SensorId).Result;
        if (!sensorResult.IsSuccessful)
        {
            return Results.NotFound(sensorResult.Error.Message);
        }
        Sensor sensor = sensorResult.Value;

        if (sensor.DeviceId != device.Id)
        {
            return Results.BadRequest($"Sensor {sensor.Id} does not belong to the device");
        }

        //SensorValue messure = sensorValueConverter.ToGenerics(sensorValue);
        //messure.CreatedAt = DateTime.Now;

        //sensorValues.Add(messure);
    }

    // Save sensor values
    var result = messureRepository.AddMessuresAsync(sensorValues).Result;
    if (!result.IsSuccessful)
    {
        // TODO: return Internal server error
        
    }
    return Results.Ok();
}) // TODO: https://blog.jetbrains.com/dotnet/2023/04/25/introduction-to-asp-net-core-minimal-apis/
    .WithName("AddSensorData")
    .WithDescription("Save sensor data on the server")
    .WithOpenApi();

app.MapGet("/api/devices/commands", () => "0")
    .WithName("GetDeviceCommands")
    .WithDescription("Get commands for a device")
    .WithOpenApi();

Sensor sensor = new()
{
    Id = 1,
    Name = "Sensor 1",
    Description = "Sensor 1 description",
    DeviceId = 1,
    SensorValueTypeName = typeof(SensorValueIntNumber).Name,
    Messures = new List<SensorValue>
    {
        new SensorValueIntNumber
        {
            Id = 1,
            Value = 1,
            CreatedAt = DateTime.Now
        }
    }
};

string jsonString = JsonSerializer.Serialize(sensor);

Sensor sensorDeserialized = JsonSerializer.Deserialize<Sensor>(jsonString);

Console.WriteLine(sensorDeserialized.Messures.First().Value);
Console.WriteLine(sensorDeserialized.Messures.First().Value.GetType());

app.Run(); // TODO: Read port from configuration: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment
           // TODO: HTTPS: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment