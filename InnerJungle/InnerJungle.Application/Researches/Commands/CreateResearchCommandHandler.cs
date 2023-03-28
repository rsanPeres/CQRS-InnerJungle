using ErrorOr;
using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Interfaces.Repositories;
using MediatR;

namespace InnerJungle.Application.Researches.Commands
{
    public class CreateResearchCommandHandler : IRequestHandler<CreateResearchCommand, ErrorOr<GenericCommandResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateResearchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ErrorOr<GenericCommandResult>> Handle(CreateResearchCommand command, CancellationToken token)
        {
            //fail fast validatiom

            if (command.Validate().IsValid)
            {
                var user = _unitOfWork.User.GetUserByEmail(command.Research.User.Email);
                if (user is null)
                {
                    return new GenericCommandResult(
                        false,
                        "Create user first",
                        command.Research);
                }

                command.Research.SetUser(user);

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
