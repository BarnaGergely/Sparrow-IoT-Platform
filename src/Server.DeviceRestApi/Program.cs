/*
using Server.DeviceRestApi;
using Server.Application;
using Server.Infrastructure;
using Server.DeviceRestApi.Measurements;

//TODO: Deprecated, delete it


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); // TODO: CHeck in swaggler docs that is it required in production environment
builder.Services.AddSwaggerGen();

builder.Services
    .AddDeviceRestApiDependencies()
    .AddApplicationDependencies()
    .AddInfrastructureDependencies();

//builder.Services.AddProblemDetails(); // Add exception handling middleware

var app = builder.Build();

//app.UseExceptionHandler(); // TODO: check how is it works and turn on

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Docs: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/route-handlers?view=aspnetcore-8.0#route-groups
app.MapGroup("/api/measure")
    .MapMeasurementsEndpoints()
    .WithName("Measurements")
    .WithDescription("Operations with measurements")
    .WithTags("Measurements");

app.Run(); // TODO: Read port from configuration: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment
           // TODO: HTTPS: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment

*/