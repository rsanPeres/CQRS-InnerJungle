using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Domain.Queries;
using InnerJungle.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InnerJungle.Repository.Repositories
{
    public class ResearchRepository : GenericRepository<Research>, IResearchRepository
    {
        public ResearchRepository(DBContext context, ILogger logger) : base(context, logger)
        {
        }

        public override Task<bool> Create(Research entity)
        {

            return base.Create(entity);
        }

        public override async Task<IEnumerable<Research>> GetAll(User user)
        {
            try
            {
                return DbSet.Where(ResearchQueries.GetAll(user)).OrderBy(x => x.Start);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(ResearchRepository));
                return Enumerable.Empty<Research>();
            }
        }

        public IEnumerable<Research> GetAllDone(User user)
        {
            return _context.Researches.AsNoTracking().Where(ResearchQueries.GetAllDone(user)).OrderBy(x => x.Start);
        }

        public IEnumerable<Research> GetAllUndone(User user)
        {
            return _context.Researches.AsNoTracking().Where(ResearchQueries.GetAllUndone(user)).OrderBy(x => x.Start);

        }

        public IEnumerable<Research> GetByPeriod(User user, DateTime date, bool done)
        {
            return _context.Researches.AsNoTracking().Where(ResearchQueries.GetByPeriod(user, date, done)).OrderBy(x => x.Start);
        }

        public override async Task<bool> Update(Research research)
        {
            try
            {
                var existingResearch = await DbSet.Where(x => x.Id == research.Id).FirstOrDefaultAsync();
                if (existingResearch == null)
                {
                    return await Create(research);
                }
                existingResearch.UpdateTitle(research.Title);
                DbSet.Update(existingResearch);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(ResearchRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var existingResearch = await GetById(id);
                if (existingResearch == null)
                {
                    return false;
                }

                DbSet.Remove(existingResearch);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(ResearchRepository));
                return false;
            }
        }


    }
}
