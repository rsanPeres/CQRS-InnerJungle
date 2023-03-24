using FluentValidation;
using InnerJungle.Domain.Entities.Validators;

namespace InnerJungle.Controllers.Requests.Validators
{
    public class CreateResearchRequestValidator : AbstractValidator<CreateResearchRequest>
    {
        public CreateResearchRequestValidator() 
        {
            RuleFor(x => x.Eletrode).NotNull().SetValidator(new EletrodeValidator());
            RuleFor(x => x.User).NotNull().SetValidator(new UserValidator());
            RuleFor(x => x.Institution).NotNull().SetValidator(new InstitutionValidator());
            RuleFor(x => x.Title).NotNull().MinimumLength(10);
        }
    }
}
