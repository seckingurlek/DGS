using Application.Services.Repositories;
using CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.AuthRules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;
        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task EmailandIdentityNumberCanNotBeDuplicatedWhenRegistered(string email,string identityNumber)
        {
            AppUser? user = await _userRepository.GetAsync(u => u.Email == email & u.IdentityNumber == identityNumber);
            if (user != null) throw new BusinessExceptions("Mail or Identity Number already exists.");

        }
        
    }
}
