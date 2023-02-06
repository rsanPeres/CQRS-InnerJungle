using InnerJungle.Domain.Entities;
using Xunit;

namespace InnerJungle.Tests.EntityTests
{
    public class ResearchTests
    {
        private readonly Research _validResearch = new Research("Inner Jungle", true, "inner");
        private readonly Research _invalidResearch = new Research("", true, "");

        [Fact]
        public void Research_GivenAValidResearch_ShouldCreate()
        {
            Assert.True(_validResearch.Done);

        }
    }
}
