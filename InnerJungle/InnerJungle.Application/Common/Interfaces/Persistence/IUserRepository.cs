using InnerJungle.Domain.Entities;

namespace InnerJungle.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        void Add(User user);
    }
}
