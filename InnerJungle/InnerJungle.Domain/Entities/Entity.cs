using Flunt.Notifications;

namespace InnerJungle.Domain.Entities
{
    public abstract class Entity : Notifiable<Notification>, IEquatable<Entity>
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
