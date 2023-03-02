using InnerJungle.Domain.Entities;

namespace InnerJungle.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);    
    }
}
