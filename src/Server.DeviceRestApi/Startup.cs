using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.Application.IotDevice.Measurements;
using Server.DeviceRestApi.Measurements;

namespace Server.DeviceRestApi;

public static class Startup
{
    public static IServiceCollection AddDeviceRestApiServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer(); // TODO: CHeck in swaggler docs that is it required in production environment
        services.AddSwaggerGen();
        
        //services.AddProblemDetails(); // Add exception handling middleware

        return services;
    }

    public static IServiceCollection AddDeviceRestApiDependencies(this IServiceCollection services)
    {
        services.AddScoped<IMeasurementsService, MeasurementsService>();
        services.AddScoped<IMeasurementsCommandHandler, MeasurementsCommandHandler>();
        return services;
    }

    public static WebApplication ConfigureDeviceRestApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        } else {
            //app.UseExceptionHandler(); // TODO: check how is it works and turn on
        }

        app.UseHttpsRedirection();

        // Docs: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/route-handlers?view=aspnetcore-8.0#route-groups
        app.MapGroup("/api/measure")
            .MapMeasurementsEndpoints()
            .WithName("Measurements")
            .WithDescription("Operations with measurements")
            .WithTags("Measurements");

        return app;
    }
}
