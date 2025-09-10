using CrossCuttingConcerns.Exceptions;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior< TRequest, TResponse> where TRequest : notnull, IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            if (roleClaims == null || !roleClaims.Any())
                throw new AuthorizationException("Claims not found.");

            bool hasMatchingRole = request.Roles.Any(role => roleClaims.Contains(role));

            if (!hasMatchingRole)
                throw new AuthorizationException("You are not authorized.");

            // Request pipeline devam etsin
            return await next();
        }
    }
}
