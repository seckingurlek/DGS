using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserOperationClaim : Entity
    {
        public Guid UserId { get; set; }

        public int OperationClaimId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }



    }
}
