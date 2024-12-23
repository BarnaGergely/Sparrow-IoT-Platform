using Application;
using Infrastructure;
using IotRestApi;
using WebApp.Server;

var builder = WebApplication.CreateBuilder(args);

// Service registration
builder.Services
    .AddIoTRestApiServices()
    .AddWebAppServerServices();

// Dependency injection
builder.Services
    .AddApplicationDependencies()
    .AddInfrastructureDependencies()
    .AddWebAppServerDependencies()
    .AddIotRestApiDependencies();

var app = builder.Build();

// TODO: Solve static assets problem
app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseExceptionHandler(); // TODO: Add exception handling middleware

// REST Endpoint registration
app.ConfigureIotRestApiEndpoints()
    .ConfigureWebAppEndpoints();

app.Run();