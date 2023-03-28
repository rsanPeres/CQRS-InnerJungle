using FluentValidation;
using InnerJungle.Application.Researches.Commands;
using InnerJungle.Domain.Entities.Validators;

namespace InnerJungle.Application.Researches.Common.Validators
{
    public class CreateResearchCommandValidator : AbstractValidator<CreateResearchCommand>
    {
        public CreateResearchCommandValidator()
        {
            RuleFor(x => x.Research).NotNull().SetValidator(new ResearchValidator());
        }
    }
}
