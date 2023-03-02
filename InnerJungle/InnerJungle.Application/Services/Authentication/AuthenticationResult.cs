using InnerJungle.Domain.Entities;

namespace InnerJungle.Application.Services.Authentication
{
        public record AuthenticationResult(
            User user,
            string token
            );
}
