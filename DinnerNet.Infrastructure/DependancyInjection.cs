
using DinnerNet.Application.Common.Interfaces;
using DinnerNet.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerNet.Infrastructure;

public static class DependancyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
     ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}