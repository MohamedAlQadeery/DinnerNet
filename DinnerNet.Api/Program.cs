using DinnerNet.Application.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
}
// Add services to the container.


var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();

}

