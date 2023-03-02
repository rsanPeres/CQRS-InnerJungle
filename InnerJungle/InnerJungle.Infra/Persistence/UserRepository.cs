using InnerJungle.Application.Common.Interfaces.Persistence;
using InnerJungle.Domain.Entities;

namespace InnerJungle.Infra.Persistence
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
