using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Interfaces
{
    public interface IResearchRepository
    {
        void Create(Research research);
        void Update(Research research);
        Research GetById(Guid id, string user);
        IEnumerable<Research> GetAll(string user);
        IEnumerable<Research> GetAllDone(string user);
        IEnumerable<Research> GetAllUndone(string user);
        IEnumerable<Research> GetByPeriod(string user, DateTime date, bool done);
        void SaveChanges();

    }
}
