using FluentResults;

namespace InnerJungle.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

    }
}