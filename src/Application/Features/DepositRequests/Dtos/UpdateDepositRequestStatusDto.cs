using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DepositRequests.Dtos
{
    public class UpdateDepositRequestStatusDto
    {
        public string TenantIdentityNumber { get; set; }
        public bool IsAccepted { get; set; }
    }
}
