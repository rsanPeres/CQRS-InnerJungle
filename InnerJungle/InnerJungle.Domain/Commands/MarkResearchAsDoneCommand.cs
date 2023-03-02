using Flunt.Notifications;
using Flunt.Validations;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerJungle.Domain.Commands
{
    public class MarkResearchAsDoneCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public User User { get; set; }

        public MarkResearchAsDoneCommand(Guid id, User user)
        {
            Id = id;
            User = user;
        }

        public MarkResearchAsDoneCommand()
        {

        }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
            );
        }
    }
}
