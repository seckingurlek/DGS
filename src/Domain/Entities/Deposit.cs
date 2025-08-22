using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Deposit :Entity
    {
        public Guid PropertyId { get; set; }
        public virtual Property Property { get; set; }

        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual Landlord Landlord { get; set; }
        public Guid LandlordId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DepositAmount { get; set; }

        public bool IsActive { get; set; } = true;
       


    }
}
