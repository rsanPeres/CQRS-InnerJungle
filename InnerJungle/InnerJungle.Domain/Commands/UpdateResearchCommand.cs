using Flunt.Notifications;
using Flunt.Validations;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Commands
{
    public class UpdateResearchCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public User User { get; set; }

        public UpdateResearchCommand(Guid id, string title, User user)
        {
            Id = id;
            Title = title;
            User = user;
        }
        public UpdateResearchCommand() { }
        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(Title, 3, "Title", "Describe better the title")
            );
        }
    }
}
