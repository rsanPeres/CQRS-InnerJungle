using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Interfaces;

namespace InnerJungle.Tests.Repositories
{
    public class FakeResearchRepository : IResearchRepository
    {
        public void Create(Research research)
        {
        }

        public IEnumerable<Research> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Research> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Research> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public Research GetById(Guid id, string user)
        {
            return new Research("inner", true, "Jungle");
        }

        public IEnumerable<Research> GetByPeriod(string user, DateTime date, bool done)
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
