namespace WebApp.Server;

public static class Startup
{
    public static IServiceCollection AddWebAppServerServices(this IServiceCollection services)
    {
        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        return services;
    }
    public static IServiceCollection AddWebAppServerDependencies(this IServiceCollection services)
    {
        return services;
    }
    public static WebApplication ConfigureWebAppServer(this WebApplication app)
    {
        app.UseDefaultFiles();
        app.MapStaticAssets();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.MapGroup("api").MapGroup("web").MapDeviceEndpoints();

        app.MapFallbackToFile("/index.html");

        return app;
    }

    internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
