using ErrorOr;
using FluentValidation.Results;
using InnerJungle.Application.Researches.Common.Validators;
using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Entities;
using MediatR;

namespace InnerJungle.Application.Researches.Commands
{
    public class CreateResearchCommand : ICommand, IRequest<ErrorOr<GenericCommandResult>>
    {
        public readonly Guid Id;
        public Research Research { get; set; }

    public CreateResearchCommand(Research research)
    {
        Research = research;
        Id = Guid.NewGuid();
    }

    public CreateResearchCommand()
    {

    }

    public ValidationResult Validate()
    {
        return new CreateResearchCommandValidator().Validate(this);
    }

        public Guid GetId()
        {
            return Id;
        }
    }
}
