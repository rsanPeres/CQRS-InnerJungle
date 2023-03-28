using FluentValidation;

namespace InnerJungle.Domain.Entities.Validators
{
    public class ResearchValidator : AbstractValidator<Research>
    {
        public ResearchValidator() 
        { 
            RuleFor(x => x.Title).NotEmpty().NotNull();
            //RuleFor(x => x.Eletrode).NotNull().SetValidator(new EletrodeValidator());
        }
    }
}
