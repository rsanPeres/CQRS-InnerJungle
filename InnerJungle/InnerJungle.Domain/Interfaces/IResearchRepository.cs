using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Interfaces
{
    public interface IResearchRepository
    {
        void Create(Research research);
        void Update(Research research);
        Research GetById(Guid id, User user);
        IEnumerable<Research> GetAll(User user);
        IEnumerable<Research> GetAllDone(User user);
        IEnumerable<Research> GetAllUndone(User user);
        IEnumerable<Research> GetByPeriod(User user, DateTime date, bool done);
        void SaveChanges();

    }
}
