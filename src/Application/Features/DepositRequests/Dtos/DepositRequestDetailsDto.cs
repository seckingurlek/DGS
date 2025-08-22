using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DepositRequests.Dtos
{
    public class DepositRequestDetailsDto
    {
        public Guid Id { get; set; }
        public string LandlordFullName { get; set; } 
        public string TenantFullName { get; set; } 
        public decimal DepositAmount { get; set; }
        public bool IsAccepted { get; set; }
        public string TenantEmail { get; set; }

        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }

    }
}
