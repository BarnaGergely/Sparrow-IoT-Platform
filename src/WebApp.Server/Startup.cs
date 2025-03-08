using Infrastructure.Common.Data;
using Microsoft.AspNetCore.Identity;
using WebApp.Server.Auth;
using WebApp.Server.Measurements;


namespace WebApp.Server;

public static class Startup
{
    public static IServiceCollection AddWebAppServerServices(this IServiceCollection services)
    {
        services.AddAuthorization();

        // TODO: move it to the Infrastructure layer
        services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        return services;
    }

    public static IServiceCollection AddWebAppServerDependencies(this IServiceCollection services)
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

    public static WebApplication ConfigureWebAppServer(this WebApplication app)
    {
        app.UseDefaultFiles();
        app.MapStaticAssets();

        app.UseHttpsRedirection();

        var apiGroup = app.MapGroup("api");
        apiGroup.MapGroup("web")
            .MapDevicesEndpoints()
            .MapSensorsEndpoints()
            .MapMeasurementsEndpoints()
            .MapGroup("auth")
                .MapIdentityEndpoints();

        return app;
    }
}
