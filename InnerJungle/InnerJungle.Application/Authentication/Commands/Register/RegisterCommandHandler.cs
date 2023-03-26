using ErrorOr;
using InnerJungle.Application.Authentication.Common;
using InnerJungle.Application.Common.Interfaces.Authentication;
using InnerJungle.Domain.Common.Errors;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Interfaces.Repositories;
using MediatR;

namespace InnerJungle.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;


        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (_unitOfWork.User.GetUserByEmail(command.Email) is not null)
            {
                return ErrorsUser.DuplicateEmail;
            }

            var user = new User(command.FistName, command.LastName, command.Email, command.Password, command.Cpf, command.UserName);

            await _unitOfWork.User.Create(user);
            await _unitOfWork.CompleteAsync();

            return new AuthenticationResult(user, "");
        }
    }
}
