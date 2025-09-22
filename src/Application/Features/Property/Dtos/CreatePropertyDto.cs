using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Property.Dtos
{
    public class CreatePropertyDto
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal DepositAmount { get; set; }
        public bool IsAvailable { get; set; }
    }
}
