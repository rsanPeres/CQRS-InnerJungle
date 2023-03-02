using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Enums;
using InnerJungle.Domain.Interfaces;

namespace InnerJungle.Tests.Repositories
{
    public class FakeResearchRepository : IResearchRepository
    {
        public void Create(Research research)
        {
        }

        public IEnumerable<Research> GetAll(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Research> GetAllDone(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Research> GetAllUndone(User user)
        {
            throw new NotImplementedException();
        }

        public Research GetById(Guid id, User user)
        {
            return new Research("inner", new User("", "", RoleNames.Default, ""));
        }

        public IEnumerable<Research> GetByPeriod(User user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Research research)
        {
        }
    }
}
