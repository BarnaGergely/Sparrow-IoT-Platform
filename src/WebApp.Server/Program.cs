using Application;
using Infrastructure;
using WebApp.Server;

var builder = WebApplication.CreateBuilder(args);

// Service registration
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices()
    .AddWebAppServerServices();


// Dependency injection
builder.Services
    .AddApplicationDependencies()
    .AddInfrastructureDependencies()
    .AddWebAppServerDependencies();

var app = builder.Build();

app.UseHttpsRedirection();
// app.UseExceptionHandler(); // TODO: Add exception handling middleware

// REST Endpoint registration and other config
app.ConfigureOpenApi();
app.ConfigureWebAppServer();

app.Run();