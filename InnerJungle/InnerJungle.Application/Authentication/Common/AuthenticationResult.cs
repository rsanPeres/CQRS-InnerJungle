using InnerJungle.Domain.Entities;

namespace InnerJungle.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string Token);
}
