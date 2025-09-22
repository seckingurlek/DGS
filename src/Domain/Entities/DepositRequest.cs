using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum DepositRequestStatus
    {
        Pending,   // Yeni gönderildi
        Accepted,  // Tenant kabul etti
        Rejected   // Tenant reddetti
    }
    public class DepositRequest :Entity
    {
       
        public Guid PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public string TenantIdentityNumber { get; set; }

        public Guid LandlordId { get; set; }
        public virtual Landlord Landlord { get; set; }

        public virtual Tenant Tenant { get; set; }
        public Guid TenantId { get; set; }
        public string TenantEmail { get; set; }
        public string TenantPhoneNumber { get; set; }

        public decimal DepositAmount { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public bool? IsAccepted { get; set; } = null;
        public DepositRequestStatus Status { get; set; } = DepositRequestStatus.Pending;
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
    }
}
