using Flunt.Notifications;
using Flunt.Validations;

namespace InnerJungle.Domain.Entities
{
    public abstract class ResearchBase : Entity
    {
        public string Title { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? End { get; private set; }
        public bool Done { get; private set; }


        public ResearchBase(string title)
        {
            Validate(title);
            Start = DateTime.UtcNow;
            Title = title;
            Done = false;
        }

        public void Validate(string title)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNullOrWhiteSpace(title, "Invalid Title", "Invalid Title"));
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void MarkAsDone()
        {
            End = DateTime.UtcNow;
            Done = true;
        }
    }
}
