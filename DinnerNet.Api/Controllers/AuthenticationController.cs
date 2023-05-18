using DinnerNet.Application.Authentication.Commands;
using DinnerNet.Application.Authentication.Common;
using DinnerNet.Application.Authentication.Queries;
using DinnerNet.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace DinnerNet.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]

    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var registerCommand = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

        var result = await _mediator.Send(registerCommand);


        return result.Match(
              result => Ok(MapAuthenticationResponse(result)),
              errors => Problem(errors)
          );

    }



    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {

        var loginQuery = new LoginQuery(request.Email, request.Password);
        var result = await _mediator.Send(loginQuery);



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
