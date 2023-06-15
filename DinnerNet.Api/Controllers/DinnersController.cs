using DinnerNet.Application.Dinners.Commands;
using DinnerNet.Contracts.Dinners;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerNet.Api.Controllers;

[Route("/hosts/{hostId}/dinners")]
public class DinnersController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public DinnersController(ISender mediator, IMapper mapper)
    {
        _mapper = mapper;
        _mediator = mediator;

    }

    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }

    [HttpPost]
    public async Task<IActionResult> CreateDinner(CreateDinnerRequest request, string hostId)
    {
        var createDinnerCommand = _mapper.Map<CreateDinnerCommand>((request, hostId));
        var result = await _mediator.Send(createDinnerCommand);
        return result.Match(
            dinner => Ok(dinner),
            error => Problem(error));

    }
}