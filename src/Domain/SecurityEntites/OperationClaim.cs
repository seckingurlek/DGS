using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SecurityEntities
{
    public class OperationClaim : Entity
    {
        public string Name { get; set; }

        public OperationClaim()
        {
            
        }

        public OperationClaim(Guid id, string name, DateTime createdAt) :base(id, createdAt)
        {
            Name = name;
            CreatedAt = createdAt;
        }
    }
}
