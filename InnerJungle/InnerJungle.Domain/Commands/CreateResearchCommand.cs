using FluentValidation.Results;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Commands.Validators;
using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Commands
{
    public class CreateResearchCommand : ICommand
    {
        public Research Research { get; set; }

        public CreateResearchCommand(Research research)
        {
            Research = research;
        }

        public CreateResearchCommand()
        {

        }

        public ValidationResult Validate()
        {
            return new CreateResearchCommandValidator().Validate(this);
        }
    }
}
