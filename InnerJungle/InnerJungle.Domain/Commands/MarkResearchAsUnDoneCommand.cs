using FluentValidation.Results;
using Flunt.Notifications;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Commands.Validators;
using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Commands
{
    public class MarkResearchAsUnDoneCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public Research Research { get; set; }
        public User User { get; set; }

        public MarkResearchAsUnDoneCommand(Guid id, User user, Research research)
        {
            User = user;
            Research = research;
        }

        public MarkResearchAsUnDoneCommand()
        {

        }

        public ValidationResult Validate()
        {
            return new MarkResearchAsUnDoneCommandValidator().Validate(this);
        }

        public Guid GetId()
        {
            return Id;
        }
    }
}

