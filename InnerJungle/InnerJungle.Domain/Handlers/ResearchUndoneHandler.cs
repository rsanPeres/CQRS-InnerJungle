using Flunt.Notifications;
using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Handlers.Contracts;
using InnerJungle.Domain.Interfaces.Repositories;

namespace InnerJungle.Domain.Handlers
{
    public class ResearchUndoneHandler : Notifiable<Notification>, IHandler<MarkResearchAsUnDoneCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResearchUndoneHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ICommandResult> Handle(MarkResearchAsUnDoneCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                var research = _unitOfWork.Research.GetById(command.Id).Result;
                if (research != null)
                {
                    await _unitOfWork.Research.Update(research);
                    await _unitOfWork.CompleteAsync();
                    return new GenericCommandResult(true, "saved Task", research);
                }
            }
            return new GenericCommandResult(false, "wrong task", command.Notifications);
        }
    }
}
