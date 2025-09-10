using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tenant : AppUser
    {

        public virtual ICollection<Deposit>? Deposits { get; set; } = new List<Deposit>();
        public virtual ICollection<DepositRequest>? DepositRequests { get; set; } = new List<DepositRequest>();

    }
}
