using Application.Features.Auths.AuthRules;
using Application.Features.Auths.Dtos;
using Application.Services.AuthService;
using Application.Services.Repositories;
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
    public class RegisterCommand:IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            public RegisterCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService  )
            {
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
            }
            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EmailandIdentityNumberCanNotBeDuplicatedWhenRegistered(request.UserForRegisterDto.IdentityNumber, request.UserForRegisterDto.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                AppUser newUser;

                if (request.UserForRegisterDto.Role == "Tenant")
                {
                    newUser = new Domain.Entities.Tenant
                    {
                        Email = request.UserForRegisterDto.Email,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        FirstName = request.UserForRegisterDto.FirstName,
                        LastName = request.UserForRegisterDto.LastName,
                        IdentityNumber = request.UserForRegisterDto.IdentityNumber,
                        PhoneNumber = request.UserForRegisterDto.PhoneNumber,
                    };
                }
                else if (request.UserForRegisterDto.Role == "Landlord")
                {
                    newUser = new Landlord
                    {
                        Email = request.UserForRegisterDto.Email,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        FirstName = request.UserForRegisterDto.FirstName,
                        LastName = request.UserForRegisterDto.LastName,
                        IdentityNumber = request.UserForRegisterDto.IdentityNumber,
                        PhoneNumber = request.UserForRegisterDto.PhoneNumber
                    };
                }
                else
                {
                    throw new Exception("Geçersiz kullanıcı tipi. Sadece 'Tenant' veya 'Landlord' olabilir.");
                }


                AppUser createdUser = await _userRepository.AddAsync(newUser);
                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredDto registeredDto = new()
                {
                    RefreshToken = addedRefreshToken.Token,
                    AccessToken = createdAccessToken,
                };
                return registeredDto;
            }
        }
    }
}
