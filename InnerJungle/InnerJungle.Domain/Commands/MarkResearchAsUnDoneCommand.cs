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
    public class MarkResearchAsUnDoneCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public string User { get; set; }

        public MarkResearchAsUnDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public MarkResearchAsUnDoneCommand()
        {

        }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(User, 6, "User", "Invalid User")
            );
        }
    }
}
