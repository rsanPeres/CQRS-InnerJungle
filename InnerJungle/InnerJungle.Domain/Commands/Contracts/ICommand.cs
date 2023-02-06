using Flunt.Notifications;
using Flunt.Validations;

namespace InnerJungle.Domain.Commands.Contracts
{
    public interface ICommand
    {
        public void Validate();
    }
}
