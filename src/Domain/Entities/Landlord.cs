using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Landlord : AppUser
    {
        public virtual ICollection<Property>? Properties { get; set; } = new List<Property>();
        public virtual ICollection<DepositRequest> DepositRequests { get; set; }
        public virtual ICollection<Deposit>? Deposits { get; set; } = new List<Deposit>();
    }
}
