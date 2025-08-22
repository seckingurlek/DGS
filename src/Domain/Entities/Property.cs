using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Property :Entity
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal DepositAmount { get; set; }
        public bool IsAvailable { get; set; } = true;
        public virtual Landlord Landlord { get; set; }
        public Guid LandlordId { get; set; }
        public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
    }
}
