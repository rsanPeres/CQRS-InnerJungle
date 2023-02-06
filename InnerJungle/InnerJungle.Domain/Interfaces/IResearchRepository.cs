using InnerJungle.Domain.Entities;

namespace InnerJungle.Domain.Interfaces
{
    public interface IResearchRepository
    {
        void Create(Research research);
        void Update(Research research);
        Research GetById(Guid id, string user);
    }
}
