using Flunt.Notifications;
using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Handlers.Contracts;
using InnerJungle.Domain.Interfaces.Repositories;

namespace InnerJungle.Domain.Handlers
{
    public class CreateResearchHandler : IHandler<CreateResearchCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateResearchHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ICommandResult> Handle(CreateResearchCommand command)
        {
            //fail fast validatiom
            
            if (command.Validate().IsValid)
            {

                await _unitOfWork.Research.Create(command.Research);
                await _unitOfWork.CompleteAsync();

                return new GenericCommandResult(true, "saved Task", command.Research);
            }
            return new GenericCommandResult(
                false,
                "wrong task",
                command.Research);
        }
    }
}
