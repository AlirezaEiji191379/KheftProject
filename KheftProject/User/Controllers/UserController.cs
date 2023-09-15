using KheftProject.User.Business.Contracts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KheftProject.User.Controllers;

[ApiController]
[Route("User")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationCommand userRegistrationCommand)
    {
        var responseDto = await _mediator.Send(userRegistrationCommand);
        return StatusCode(responseDto.StatusCode, new { Message = responseDto.Message });
    }
}