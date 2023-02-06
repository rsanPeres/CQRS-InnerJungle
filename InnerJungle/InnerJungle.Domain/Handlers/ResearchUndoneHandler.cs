using Flunt.Notifications;
using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Handlers.Contracts;
using InnerJungle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerJungle.Domain.Handlers
{
    public class ResearchUndoneHandler : Notifiable<Notification>, IHandler<MarkResearchAsUnDoneCommand>
    {
        private readonly IResearchRepository _repository;

        public ICommandResult Handle(MarkResearchAsUnDoneCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                var research = _repository.GetById(command.Id, command.User);
                if (research != null)
                {
                    research.MarkAsUnDone();
                    _repository.Update(research);
                    return new GenericCommandResult(true, "saved Task", research);
                }
            }
            return new GenericCommandResult(false, "wrong task", command.Notifications);
        }
    }
}
