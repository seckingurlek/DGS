using Application.Services.Repositories;
using Core.Security.JWT;
using Domain.Entities;
using Domain.SecurityEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthService(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository  )
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync( refreshToken );
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(AppUser user)
        {
            var userOperationClaims = await _userOperationClaimRepository.GetListAsync(
            uoc => uoc.UserId == user.Id,
            include: uoc => uoc.Include(u => u.OperationClaim) /* EF Core Include*/);

            IList<OperationClaim> operationClaims =
               userOperationClaims.Select(u => new OperationClaim
               { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();


            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public async Task<RefreshToken> CreateRefreshToken(AppUser user, string ipAdress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateResfreshToken(user, ipAdress);
            return await Task.FromResult( refreshToken );
        }
    }
}
