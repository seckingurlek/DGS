using Application.Features.Auths.AuthCommands;
using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Domain.SecurityEntities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : BaseController
    {

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new RegisterCommand()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };
            RegisteredDto result = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new LoginCommand()
            {
                UserForLoginDto = userForLoginDto,
                IpAddress = GetIpAddress()
            };
            LoggedInDto result = await Mediator.Send(loginCommand);
            return Ok(result);
        }

        private void SetRefreshTokenToCookie(string refreshToken)
        {
            CookieOptions cookieOptions = new CookieOptions() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
