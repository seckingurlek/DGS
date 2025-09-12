using Core.Security.JWT;
using Domain.Entities;
using Domain.SecurityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(AppUser user);
        public Task<RefreshToken> CreateRefreshToken(AppUser user, string ipAdress);
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    }
}
