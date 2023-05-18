using DinnerNet.Application.Services.Authentication;
using DinnerNet.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
namespace DinnerNet.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]

    public IActionResult Register([FromBody] RegisterRequest request)
    {
        var result = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return result.Match(
              result => Ok(MapAuthenticationResponse(result)),
              errors => Problem(errors)
          );

    }



    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = _authenticationService.Login(request.Email, request.Password);



        return result.Match(
            result => Ok(MapAuthenticationResponse(result)),
            errors => Problem(errors)
        );
    }


    private static AuthenticationResponse MapAuthenticationResponse(AuthenticationResult result)
    {
        return new AuthenticationResponse
        (result.User.Id,
         result.User.FirstName,
         result.User.LastName,
         result.User.Email,
         result.Token);
    }
}
