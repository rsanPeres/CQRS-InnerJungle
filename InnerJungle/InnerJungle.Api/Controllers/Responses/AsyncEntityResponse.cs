using InnerJungle.Domain.Commands.Contracts;

namespace InnerJungle.Controllers.Responses
{
    public class AsyncEntityResponse
    {
        public readonly Guid Id;
        public readonly CommandResponse Command;
        public AsyncEntityResponse(ICommand command, Guid id)
        {
            Id= id;
            Command = new CommandResponse()
            {
                Id = Command.Id,

            };
        }
    }
}
