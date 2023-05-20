using DinnerNet.Api.Common.Errors;
using DinnerNet.Api.Common.Mappings;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DinnerNet.Api;

public static class DependancyInjection
{

    public static IServiceCollection AddPresentaion(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, DinnerDefaultProblemFactory>();

        return services;
    }
}