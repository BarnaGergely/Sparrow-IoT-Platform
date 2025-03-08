using Application;
using Infrastructure;
using IotRestApi;

var builder = WebApplication.CreateBuilder(args);

// Service registration
builder.Services
    .AddIoTRestApiServices()
    .AddOpenApiServices();

// Dependency injection
builder.Services
    .AddApplicationDependencies()
    .AddInfrastructureDependencies()
    .AddIotRestApiDependencies()
    .AddOpenApiDependencies();

var app = builder.Build();
app.UseHttpsRedirection();
// app.UseExceptionHandler(); // TODO: Add exception handling middleware

// REST Endpoint registration
app.ConfigureIotRestApi();
app.ConfigureOpenApi();

app.Run();