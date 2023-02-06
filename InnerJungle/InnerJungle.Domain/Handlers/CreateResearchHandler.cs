using Flunt.Notifications;
using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Handlers.Contracts;
using InnerJungle.Domain.Interfaces;

namespace InnerJungle.Domain.Handlers
{
    public class CreateResearchHandler : Notifiable<Notification>, IHandler<CreateResearchCommand>
    {
        private readonly IResearchRepository _repository;

        public CreateResearchHandler(IResearchRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateResearchCommand command)
        {
            //fail fast validatiom
            command.Validate();
            if(command.IsValid)
            {
                var research = new Research(command.Title, command.Done, command.User);
            
                _repository.Create(research);

                return new GenericCommandResult(true, "saved Task", research);
            }
            return new GenericCommandResult(
                false,
                "wrong task",
                command.Notifications);
        }
    }
}
