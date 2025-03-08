using Application.IotDevice.Measurements;
using IotRestApi.Measurements;

namespace IotRestApi;

public static class Startup
{
    public static IServiceCollection AddIoTRestApiServices(this IServiceCollection services)
    {
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
        RouteGroupBuilder groupBuilder = app.MapGroup("api").MapGroup("iot")
            .WithName("IoT Devices")
            .WithDescription("APIs to communicate with IoT devices")
            .WithTags("IoT");

        groupBuilder.MapMeasurementsEndpoints();

        return app;
    }

    public static IServiceCollection AddOpenApiServices(this IServiceCollection services) 
    {
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();
        return services;
    }

    public static IServiceCollection AddOpenApiDependencies(this IServiceCollection services)
    {
        return services;
    }

    public static WebApplication ConfigureOpenApi(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            // In the future we should use Scalar for production environments
            // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/using-openapi-documents?view=aspnetcore-9.0
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
            });
        }
        return app;
    }
}
