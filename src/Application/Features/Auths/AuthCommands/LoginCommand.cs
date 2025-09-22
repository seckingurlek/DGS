using Application.Features.Auths.AuthRules;
using Application.Features.Auths.Dtos;
using Application.Services.AuthService;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using Domain.SecurityEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.AuthCommands
{
    public class LoginCommand :IRequest<LoggedInDto> 
    {
        public  UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }
    }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedInDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public LoginCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules )
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }
        public async Task<LoggedInDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userRepository.GetAsync( u => u.IdentityNumber == request.UserForLoginDto.IdentityNumber );
            await _authBusinessRules.UserShouldBeExist(user.IdentityNumber );
            bool passwordVerified = HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (! passwordVerified )
            {
                throw new Exception("Hstslı şifre girdiniz.;");
            }
            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
            RefreshToken addedRefrehToken = await _authService.AddRefreshToken(createdRefreshToken);

            return new LoggedInDto
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefrehToken.Token
            };
        }
    }
}
