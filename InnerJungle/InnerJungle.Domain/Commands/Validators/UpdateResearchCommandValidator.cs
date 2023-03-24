using FluentValidation;
using InnerJungle.Domain.Entities.Validators;

namespace InnerJungle.Domain.Commands.Validators
{
    public class UpdateResearchCommandValidator : AbstractValidator<UpdateResearchCommand>
    {
        public UpdateResearchCommandValidator()
        {
            RuleFor(x => x.Research).NotNull().SetValidator(new ResearchValidator());
            RuleFor(x => x.User).NotNull().SetValidator(new UserValidator());
        }
    }
}
