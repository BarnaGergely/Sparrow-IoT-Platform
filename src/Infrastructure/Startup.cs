using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Common.Data;
using Application.IotDevice;
using Application.Web;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IIotRepository, IotRepository>();
        services.AddScoped<IWebRepository, WebRepository>();
        return services;
    }
}
