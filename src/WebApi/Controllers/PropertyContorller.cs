using Application.Features.Landlords.Dtos;
using Application.Features.Property.Commands.CreateProperty;
using Application.Features.Property.Dtos;
using Core.Security.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyContorller : BaseController
    {
        

        [HttpPost("CreateProperty")]
        //[Authorize(Roles = "Landlord")]
        public async Task<IActionResult> Add([FromBody] CreatePropertyCommand createPropertyCommand)
        {
            CreatedPropertyDto result = await Mediator.Send(createPropertyCommand);
            return Created("", result);

        }

    }
}

