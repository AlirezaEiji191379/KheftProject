using KheftProject.Book.Business.Contracts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KheftProject.Book.Controllers;

[ApiController]
[Route("Book")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Add")]
    public async Task<IActionResult> AddBook([FromBody] BookCreationCommand bookCreationCommand)
    {
        var response = await _mediator.Send(bookCreationCommand);
        return StatusCode(response.StatusCode, new {Message = response.Message});
    }

    [HttpPatch]
    [Route("Accpet")]
    public async Task<IActionResult> AcceptBook([FromBody] BookAcceptCommand bookAcceptCommand)
    {
        var response = await _mediator.Send(bookAcceptCommand);
        return StatusCode(response.StatusCode, new {Message = response.Message});
    }
    
}