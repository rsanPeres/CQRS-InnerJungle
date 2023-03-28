using Flunt.Notifications;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Handlers.Contracts;
using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Handlers
{
    public class ResearchDoneHandler : Notifiable<Notification>, IHandler<MarkResearchAsDoneCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResearchDoneHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ICommandResult> Handle(MarkResearchAsDoneCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                var research = await _unitOfWork.Research.GetById(command.Research.Id);
                if (research != null)
                {
                    research.MarkAsDone();
                    await _unitOfWork.Research.Update(research);
                    await _unitOfWork.CompleteAsync();
                    return new GenericCommandResult(true, "saved Task", research);
                }
            }
            return new GenericCommandResult(false, "wrong task", command.Notifications);
        }
    }
}
