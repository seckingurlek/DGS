using Domain.Entities;
using Domain.SecurityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AppUser user, IList<OperationClaim> operationClaims);
        RefreshToken CreateResfreshToken(AppUser user, string ipAdress);
    }
}
