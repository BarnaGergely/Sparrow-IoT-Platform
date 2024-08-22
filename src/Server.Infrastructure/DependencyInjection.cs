﻿using Microsoft.Extensions.DependencyInjection;
using Server.Application.Common.Interfaces;

namespace Server.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure (this IServiceCollection services)
    {
        services.AddDbContext<MeasurementsContext>();
        services.AddScoped<IMeasurementsRepository, MeasurementsRepository>();
        return services;
    }
}
