using FluentResults;
using InnerJungle.Application.Common.Errors;
using InnerJungle.Application.Common.Interfaces.Authentication;
using InnerJungle.Application.Common.Interfaces.Persistence;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Enums;

namespace InnerJungle.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Result<AuthenticationResult> Register(string firstName, string lastname, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailException() });
            }

            var user = new User("sa", "", RoleNames.Default, "", firstName, lastname, email);

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }

    }
}
