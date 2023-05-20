using DinnerNet.Api;
using DinnerNet.Api.Common.Errors;
using DinnerNet.Api.Middlewares;
using DinnerNet.Application;
using DinnerNet.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services
    .AddPresentaion()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
}


var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    // app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();


    app.MapControllers();

    app.Run();

}

