using DinnerNet.Api.Middlewares;
using DinnerNet.Application;
using DinnerNet.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
}


var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    // app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();


    app.MapControllers();

    app.Run();

}

