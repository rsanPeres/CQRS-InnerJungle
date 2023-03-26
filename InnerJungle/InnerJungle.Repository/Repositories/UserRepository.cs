using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Infra.Contexts;
using Microsoft.Extensions.Logging;

namespace InnerJungle.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DBContext context, ILogger logger) : base(context, logger)
        {
        }

        public User GetUserByEmail(string email)
        {
            return DbSet.Where(x => x.Email == email).FirstOrDefault();
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }
    }
}
