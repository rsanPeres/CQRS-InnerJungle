using FluentValidation.Results;
using Flunt.Notifications;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Commands.Validators;
using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Commands
{
    public class MarkResearchAsDoneCommand : Notifiable<Notification>, ICommand
    {
        public Research Research { get; set; }
        public User User { get; set; }

        public MarkResearchAsDoneCommand(Research research, User user)
        {
            Research = research;
            User = user;
        }

        public MarkResearchAsDoneCommand()
        {

        }

        public ValidationResult Validate()
        {
            return new MarkResearchAsDoneCommandValidator().Validate(this);
        }
    }
}
