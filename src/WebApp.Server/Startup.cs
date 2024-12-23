using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;

namespace WebApp.Server;

public static class Startup
{
    public static IServiceCollection AddWebAppServerServices(this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection AddWebAppServerDependencies(this IServiceCollection services)
    {

        return services;
    }

    public static IEndpointRouteBuilder ConfigureWebAppEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapDeviceEndpoints();

        app.MapFallbackToFile("/index.html"); // TODO: Why does this needed?

        return app;
    }
}
