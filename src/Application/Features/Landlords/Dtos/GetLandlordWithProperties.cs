using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Landlords.Dtos
{
    public class GetLandlordWithProperties
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Domain.Entities.Property> Properties { get; set; } = new();

    }
}
