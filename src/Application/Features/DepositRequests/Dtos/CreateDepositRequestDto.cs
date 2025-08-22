using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DepositRequests.Dtos
{
    public class CreateDepositRequestDto
    {
        public Guid PropertyId { get; set; }
        public string TenantPhoneNumber { get; set; }


        public string? TenantFirstName { get; set; }
        public string? TenantLastName { get; set; }
        public string? TenantEmail { get; set; }
        public string? TenantAddress { get; set; }

        public decimal DepositAmount { get; set; }
        public DateTime RentalStartDate { get; set; }
        public bool? IsAccepted { get; set; } = null;
        public DateTime RentalEndDate { get; set; }
    }
}
