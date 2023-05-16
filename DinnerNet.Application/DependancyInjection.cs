using DinnerNet.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerNet.Application;

public static class DependancyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IAuthenticationService, AuthenticationService>();
        return service;
    }
}