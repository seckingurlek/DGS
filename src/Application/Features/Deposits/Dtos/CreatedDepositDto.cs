using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Deposits.Dtos
{
    public class CreatedDepositDto
    {
        public Guid Id { get; set; }
        public string TenantFullName  { get; set; }
        public string LandlordFullName { get; set; }
        public decimal DepositAmount { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
