using Application.Features.DepositRequests.Commands.UpdateDepositRequest;
using Application.Features.DepositRequests.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers.DepositRequestController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositRequestsStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepositRequestsStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPut("{identityNumber}/status")]
        public async Task<IActionResult> UpdateStatus(string identityNumber, [FromQuery] bool isAccepted)
        {

            var updateDepositRequestStatusCommand = new UpdateDepositRequestStatusCommand
            {
                TenantIdentityNumber = identityNumber,
                IsAccepted = isAccepted
            };

            var result = await _mediator.Send(updateDepositRequestStatusCommand);
            return Ok(result);
        }
    }
}
