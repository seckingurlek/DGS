using Application.Features.DepositRequests.Commands.CreateDepositRequest;
using Application.Features.DepositRequests.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.DepositRequestController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepositRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddDepositRequest([FromBody] CreateDepositRequestCommand depositRequestCommand)
        {
            if (depositRequestCommand == null)
            {
                return BadRequest("deposit request bulunamadı");
            }
            var result = await _mediator.Send(depositRequestCommand);
            return Ok(result);
        }
    }
}
