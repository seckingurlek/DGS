using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            
        }
        public Entity(Guid id, DateTime createdAt)
        {
            Id = id;
            CreatedAt = createdAt;
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
