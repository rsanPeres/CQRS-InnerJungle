using ErrorOr;
using InnerJungle.Application.Authentication.Common;
using InnerJungle.Application.Common.Interfaces.Authentication;
using InnerJungle.Application.Common.Interfaces.Persistence;
using InnerJungle.Domain.Common.Errors;
using InnerJungle.Domain.Entities;
using MediatR;

namespace InnerJungle.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return ErrorsUser.DuplicateEmail;
            }


            var user = new User(command.FistName, command.LastName, command.Email, command.Password);

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
