using FluentValidation;
using InnerJungle.Domain.Entities.Validators;

namespace InnerJungle.Domain.Commands.Validators
{
    internal class MarkResearchAsUnDoneCommandValidator : AbstractValidator<MarkResearchAsUnDoneCommand>
    {
        public MarkResearchAsUnDoneCommandValidator()
        {
            RuleFor(x => x.Research).NotNull().SetValidator(new ResearchValidator());
            RuleFor(x => x.User).NotNull().SetValidator(new UserValidator());
        }
    }
}
