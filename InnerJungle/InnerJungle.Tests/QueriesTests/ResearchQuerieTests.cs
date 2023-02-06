using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Queries;
using System.Net.WebSockets;
using Xunit;

namespace InnerJungle.Tests.QueriesTests
{
    public class ResearchQuerieTests
    {
        private List<Research> _researches;

        public ResearchQuerieTests()
        {
            _researches= new List<Research>();
            _researches.Add(new Research("research 1", true, "userA"));
            _researches.Add(new Research("research 2", true, "inner"));
            _researches.Add(new Research("research 1", true, "userB"));
            _researches.Add(new Research("research 1", true, "inner"));

        }

        [Fact]
        public void GivenASearch_ShouldReturnDataFromInnerUser()
        {
            var result = _researches.AsQueryable().Where(ResearchQueries.GetAll("inner"));
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
