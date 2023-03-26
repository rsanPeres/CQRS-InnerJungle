using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Enums;
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

        }

        [Fact]
        public void GivenASearch_ShouldReturnDataFromInnerUser()
        {
            var result = _researches.AsQueryable().Where(ResearchQueries.GetAll(new User("", "", "", "", "")));
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
