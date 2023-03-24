using FluentValidation;
using InnerJungle.Domain.Entities.Validators;

namespace InnerJungle.Domain.Commands.Validators
{
    public class MarkResearchAsDoneCommandValidator : AbstractValidator<MarkResearchAsDoneCommand>
    {
        public MarkResearchAsDoneCommandValidator()
        {
            RuleFor(x => x.Research).NotNull().SetValidator(new ResearchValidator());
            RuleFor(x => x.User).NotNull().SetValidator(new UserValidator());
        }
    }
}
