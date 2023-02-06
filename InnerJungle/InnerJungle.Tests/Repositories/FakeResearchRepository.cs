using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Interfaces;

namespace InnerJungle.Tests.Repositories
{
    public class FakeResearchRepository : IResearchRepository
    {
        public void Create(Research research)
        {
        }

        public Research GetById(Guid id, string user)
        {
            return new Research("inner", true, "Jungle");
        }

        public void Update(Research research)
        {
        }
    }
}
