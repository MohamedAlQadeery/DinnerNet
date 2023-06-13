using System.ComponentModel.Design;
using DinnerNet.Application.Menus.Commands;
using DinnerNet.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerNet.Api.Controllers;

[Route("/hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    public MenusController(ISender mediator, IMapper mapper)
    {
        _mapper = mapper;
        _mediator = mediator;

    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var menuCommand = _mapper.Map<CreateMenuCommand>((request, hostId));
        var result = await _mediator.Send(menuCommand);

        return result.Match(menu => Ok(menu), error => Problem(error));

    }


}