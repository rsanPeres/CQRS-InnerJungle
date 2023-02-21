using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerJungle.Domain.Entities
{
    public abstract class Entity: IEquatable<Entity>
    {
        public Guid Id { get; private set; }

        protected Entity() 
        {
            Id = Guid.NewGuid();
        }

        public bool Equals(Entity? other)
        {
            return Id == other.Id;
        }
    }
}
