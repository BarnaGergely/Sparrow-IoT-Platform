using Application;
using Infrastructure;
using ThingRestApi;

var builder = WebApplication.CreateBuilder(args);

// Service registration
builder.Services
    .AddThingRestApiServices();

// Dependency injection
builder.Services
    .AddApplicationDependencies()
    .AddInfrastructureDependencies()
    .AddThingRestApiDependencies();

var app = builder.Build();

app.UseHttpsRedirection();

// REST Endpoint registration
app.ConfigureThingRestApi();

app.Run();