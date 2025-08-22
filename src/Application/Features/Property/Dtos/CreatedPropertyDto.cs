using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Property.Dtos
{
    public class CreatedPropertyDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal DepositAmount { get; set; }
        public bool IsAvailable { get; set; }
        public string? LandlordFullName { get; set; }
    }
}
