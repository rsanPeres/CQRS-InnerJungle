using InnerJungle.Application.Services.Authentication;
using MediatR;

namespace InnerJungle.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string FistName, string LastName, string email, string password) : IRequest<ErrorOr<AuthenticationResult>>;
    {

    }
}
