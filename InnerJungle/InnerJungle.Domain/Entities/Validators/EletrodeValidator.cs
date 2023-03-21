using FluentValidation;

namespace InnerJungle.Domain.Entities.Validators
{
    public class EletrodeValidator : AbstractValidator<Eletrode>
    {
        public EletrodeValidator() 
        {
            RuleFor(x => x.Name).NotEmpty()
                .NotNull();
        }
    }
}
