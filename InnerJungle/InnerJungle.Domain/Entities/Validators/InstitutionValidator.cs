using FluentValidation;

namespace InnerJungle.Domain.Entities.Validators
{
    public class InstitutionValidator : AbstractValidator<Institution>
    {
        public InstitutionValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5);
        }
    }
}
