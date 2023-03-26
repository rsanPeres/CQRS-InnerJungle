using ErrorOr;
using InnerJungle.Application.Authentication.Common;
using InnerJungle.Application.Common.Interfaces.Authentication;
using InnerJungle.Domain.Common.Errors;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Interfaces.Repositories;
using MediatR;

namespace InnerJungle.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return ErrorsAuthentication.InvalidCredentials;
            }

            if (user.Password != query.Password)
            {
                return ErrorsAuthentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
