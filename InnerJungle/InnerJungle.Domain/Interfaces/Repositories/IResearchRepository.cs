using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Interfaces.Repositories
{
    public interface IResearchRepository : IGenericRepository<Research>
    {
        IEnumerable<Research> GetAllDone(User user);
        IEnumerable<Research> GetAllUndone(User user);
        IEnumerable<Research> GetByPeriod(User user, DateTime date, bool done);

    }
}
