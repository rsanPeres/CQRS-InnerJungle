using InnerJungle.Domain.Commands.Contracts;

namespace InnerJungle.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
