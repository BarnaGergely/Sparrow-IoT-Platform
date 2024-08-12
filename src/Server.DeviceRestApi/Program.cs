// TODO: Violates Single Responsibility Principle

using Server.DeviceRestApi;
using Server.Application;
using Server.Infrastructure;
using Server.DeviceRestApi.Measurements;


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

// docs: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/route-handlers?view=aspnetcore-8.0#route-groups
app.MapGroup("/api/measure")
    .MapMeasurementsEndpoints()
    .WithName("Measurements")
    .WithDescription("Operations with measurements")
    .WithTags("Measurements");

// Test endpoint
// TODO: Remove it
app.MapGet("/api/devices/commands", () => "0")
    .WithName("GetDeviceCommands")
    .WithDescription("Get commands for a device")
    .WithOpenApi();

app.Run(); // TODO: Read port from configuration: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment
           // TODO: HTTPS: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment