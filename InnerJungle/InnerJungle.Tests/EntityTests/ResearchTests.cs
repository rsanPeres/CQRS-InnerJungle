using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Enums;
using Xunit;

namespace InnerJungle.Tests.EntityTests
{
    public class ResearchTests
    {
        private readonly Research _validResearch = new Research("Inner Jungle");
        private readonly Research _invalidResearch = new Research("Inner Jungle");

        [Fact]
        public void Research_GivenAValidResearch_ShouldCreate()
        {
            Assert.True(_validResearch.Done);

        }
    }
}
