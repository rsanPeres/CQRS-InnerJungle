using Flunt.Notifications;
using Flunt.Validations;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Commands
{
    public class CreateResearchCommand : Notifiable<Notification>, ICommand
    {
        public string Title { get; set; }
        public bool Done { get; set; }
        public User User { get; set; }

        public CreateResearchCommand(string title, bool done, User user)
        {
            Title = title;
            Done = done;
            User = user;
        }

        public CreateResearchCommand()
        {

        }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(Title, 4, "Title", "Discribe better the title")
                );
        }
    }
}
