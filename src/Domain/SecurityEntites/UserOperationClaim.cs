
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SecurityEntities
{
    public class UserOperationClaim : Entity
    {
        public Guid UserId { get; set; }

        public Guid OperationClaimId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }



    }
}
