using FluentValidation.Results;

namespace InnerJungle.Domain.Commands.Contracts
{
    public interface ICommand
    {
        public Guid GetId();
        public ValidationResult Validate();
    }
}
