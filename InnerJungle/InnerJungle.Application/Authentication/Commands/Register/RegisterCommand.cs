using ErrorOr;
using InnerJungle.Application.Authentication.Common;
using MediatR;

namespace InnerJungle.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string FistName, string LastName, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
