using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Application.IotDevice.Measurements;
using IotRestApi.Measurements;

namespace IotRestApi;

public static class Startup
{
    public static IServiceCollection AddIoTRestApiServices(this IServiceCollection services)
    {
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        return services;
    }

    public static IServiceCollection AddIotRestApiDependencies(this IServiceCollection services)
    {
        services.AddScoped<IMeasurementsService, MeasurementsService>();
        services.AddScoped<IMeasurementsCommandHandler, MeasurementsCommandHandler>();
        return services;
    }

    public static WebApplication ConfigureIotRestApi(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        RouteGroupBuilder groupBuilder = app.MapGroup("api").MapGroup("iot")
            .WithName("IoT Devices")
            .WithDescription("APIs to communicate with IoT devices")
            .WithTags("IoT");

        groupBuilder.MapGet("hello", () =>
        {
            return "Hello";
        })
        .WithName("Hello!");

        groupBuilder.MapMeasurementsEndpoints();

        return app;
    }
}
