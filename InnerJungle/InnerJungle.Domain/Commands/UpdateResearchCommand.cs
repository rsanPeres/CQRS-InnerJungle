using FluentValidation.Results;
using Flunt.Notifications;
using Flunt.Validations;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Commands.Validators;
using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Commands
{
    public class UpdateResearchCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public Research Research { get; set; }
        public User User { get; set; }

        public UpdateResearchCommand(User user, Research research)
        {
            User = user;
            Research = research;
        }
        public UpdateResearchCommand() { }
        public ValidationResult Validate()
        {
            return new UpdateResearchCommandValidator().Validate(this);
        }

        public Guid GetId()
        {
            return Id;
        }
    }
}
