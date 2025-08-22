using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Landlords.Dtos
{
    public class CreatedLandlordDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string LandlordFullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }

        public List<Domain.Entities.Property> Properties { get; set; } = new();
        public ICollection<DepositRequest>? DepositRequests { get; set; }
        public ICollection<Deposit>? Deposits { get; set; }
    }
}
