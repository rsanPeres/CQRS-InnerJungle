using InnerJungle.Domain.Commands.Contracts;

namespace InnerJungle.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
