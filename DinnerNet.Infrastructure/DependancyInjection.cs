
using Microsoft.Extensions.DependencyInjection;

namespace DinnerNet.Infrastructure;

public static class DependancyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        return service;
    }
}