using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Entities
{
    public class UserOperationClaim : Entity
    {
        public int UserId { get; set; }

        public int OperationClaimId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }


    }
}
