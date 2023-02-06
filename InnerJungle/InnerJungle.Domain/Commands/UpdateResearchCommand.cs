using Flunt.Notifications;
using Flunt.Validations;
using InnerJungle.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerJungle.Domain.Commands
{
    public class UpdateResearchCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public UpdateResearchCommand(Guid id, string title, string user)
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
                .IsGreaterOrEqualsThan(User, 3, "User", "Invalid User")
            );
        }
    }
}
