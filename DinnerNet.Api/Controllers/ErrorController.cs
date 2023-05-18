using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DinnerNet.Api.Controllers;

public class ErrorController : ApiController
{
    // [Route("/error")]
    // public IActionResult Error()
    // {
    //     var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

    //     return Problem(title: exception.Message);
    // }
}
