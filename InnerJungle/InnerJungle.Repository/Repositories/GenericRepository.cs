using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace InnerJungle.Repository.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DBContext _context;
        internal DbSet<T> DbSet;
        protected readonly ILogger _logger;

        public GenericRepository(DBContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            DbSet = _context.Set<T>();
        }

        public virtual Task<IEnumerable<T>> GetAll(User user)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<bool> Create(T entity)
        {
            await DbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public Task<bool> Commit()
        {
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
