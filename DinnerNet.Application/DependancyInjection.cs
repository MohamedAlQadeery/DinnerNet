using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerNet.Application;

public static class DependancyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependancyInjection).Assembly);
        return services;
    }
}