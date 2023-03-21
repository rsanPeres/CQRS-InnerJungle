using FluentValidation.Results;

namespace InnerJungle.Domain.Commands.Contracts
{
    public interface ICommand
    {
        public ValidationResult Validate();
    }
}
