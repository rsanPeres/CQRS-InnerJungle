using FluentValidation;

namespace InnerJungle.Domain.Entities.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
