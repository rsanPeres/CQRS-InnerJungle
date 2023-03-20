using Flunt.Notifications;
using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Handlers.Contracts;
using InnerJungle.Domain.Interfaces.Repositories;

namespace InnerJungle.Domain.Handlers
{
    public class UpdateResearchHandler : Notifiable<Notification>, IHandler<UpdateResearchCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateResearchHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ICommandResult> Handle(UpdateResearchCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                var research = _unitOfWork.Research.GetById(command.Id).Result;
                if (research != null)
                {
                    research.UpdateTitle(command.Title);
                    await _unitOfWork.Research.Update(research);
                    return new GenericCommandResult(true, "saved Task", research);
                }
            }
            return new GenericCommandResult(false, "wrong task", command.Notifications);
        }
    }
}
