using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Enums;
using InnerJungle.Domain.Interfaces;
using InnerJungle.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace InnerJungle.Tests.Repositories
{
    public class FakeResearchRepository : IResearchRepository
    {
        public Task<bool> Commit()
        {
            throw new NotImplementedException();
        }

        public void Create(Research research)
        {
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Research>> Find(Expression<Func<Research, bool>> predicate)
        {
            throw new NotImplementedException();
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

        //public Research GetById(Guid id, User user)
        //{
        //    return n;
        //}

        public Task<Research> GetById(Guid id)
        {
            throw new NotImplementedException();
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

        Task<bool> IGenericRepository<Research>.Create(Research entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Research>> IGenericRepository<Research>.GetAll(User user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenericRepository<Research>.Update(Research entity)
        {
            throw new NotImplementedException();
        }
    }
}
