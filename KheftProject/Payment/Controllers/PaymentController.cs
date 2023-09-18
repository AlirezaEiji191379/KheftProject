using KheftProject.Payment.Business.Contracts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KheftProject.Payment.Controllers;

[ApiController]
[Route("Payment")]
public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [Route("GetUrl")]
    public async Task<IActionResult> GetPaymentUrl([FromBody] PayBookCommand payBookCommand)
    {
        var result = await _mediator.Send(payBookCommand);
        return StatusCode(result.StatusCode, result.Message);
    }
    
    

}