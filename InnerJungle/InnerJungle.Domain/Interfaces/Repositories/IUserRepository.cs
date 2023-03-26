using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByEmail(string email);
        public void Add(User user);
    }
}
