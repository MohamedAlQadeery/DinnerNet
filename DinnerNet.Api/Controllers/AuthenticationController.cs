using DinnerNet.Application.Authentication.Commands;
using DinnerNet.Application.Authentication.Common;
using DinnerNet.Application.Authentication.Queries;
using DinnerNet.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace DinnerNet.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("register")]

    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {

        var registerCommand = _mapper.Map<RegisterCommand>(request);
        var registerResult = await _mediator.Send(registerCommand);


        return registerResult.Match(
              result => Ok(_mapper.Map<AuthenticationResponse>(result)),
              errors => Problem(errors)
          );

    }



    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {

        var loginQuery = new LoginQuery(request.Email, request.Password);
        var loginResult = await _mediator.Send(loginQuery);



        return loginResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            errors => Problem(errors)
        );
    }



}
