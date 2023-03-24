using FluentValidation;

namespace InnerJungle.Domain.Entities.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().MinimumLength(5);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        }
    }
}
