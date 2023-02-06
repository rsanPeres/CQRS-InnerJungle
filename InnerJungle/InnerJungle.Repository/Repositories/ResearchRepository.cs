using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Interfaces;
using InnerJungle.Domain.Queries;
using InnerJungle.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InnerJungle.Repository.Repositories
{
    public class ResearchRepository : IResearchRepository
    {
        private readonly ResearchContext _context;

        public ResearchRepository(ResearchContext context)
        {
            _context = context;
        }

        public void Create(Research research)
        {
            _context.Researches.Add(research);
            SaveChanges();
        }

        public IEnumerable<Research> GetAll(string user)
        {
            return _context.Researches.AsNoTracking().Where(ResearchQueries.GetAll(user)).OrderBy(x => x.Start);
        }

        public IEnumerable<Research> GetAllDone(string user)
        {
            return _context.Researches.AsNoTracking().Where(ResearchQueries.GetAllDone(user)).OrderBy(x => x.Start);
        }

        public IEnumerable<Research> GetAllUndone(string user)
        {
            return _context.Researches.AsNoTracking().Where(ResearchQueries.GetAllUndone(user)).OrderBy(x => x.Start);

        }

        public Research GetById(Guid id, string user)
        {
            return _context.Researches.FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public IEnumerable<Research> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Researches.AsNoTracking().Where(ResearchQueries.GetByPeriod(user, date, done)).OrderBy(x => x.Start);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Research research)
        {
            _context.Entry(research).State = EntityState.Modified;
            SaveChanges();
        }


    }
}
