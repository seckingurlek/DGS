using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Landlords.Dtos
{
    public class LandlordGetById
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
    }
}
