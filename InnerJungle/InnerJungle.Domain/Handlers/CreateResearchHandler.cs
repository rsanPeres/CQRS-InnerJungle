using Flunt.Notifications;
using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Handlers.Contracts;
using InnerJungle.Domain.Interfaces.Repositories;

namespace InnerJungle.Domain.Handlers
{
    public class CreateResearchHandler : Notifiable<Notification>, IHandler<CreateResearchCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateResearchHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ICommandResult> Handle(CreateResearchCommand command)
        {
            //fail fast validatiom
            command.Validate();
            if (command.IsValid)
            {
                var research = new Research(command.Title);

                await _unitOfWork.Research.Create(research);
                await _unitOfWork.CompleteAsync();

                return new GenericCommandResult(true, "saved Task", research);
            }
            return new GenericCommandResult(
                false,
                "wrong task",
                command.Notifications);
        }
    }
}
