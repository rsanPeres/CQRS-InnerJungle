using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Enums;
using Xunit;

namespace InnerJungle.Tests.EntityTests
{
    public class ResearchTests
    {
        private readonly Research _validResearch = new Research("Inner Jungle", new User("","", RoleNames.Default, ""));
        private readonly Research _invalidResearch = new Research("Inner Jungle", new User("", "", RoleNames.Default, ""));

        [Fact]
        public void Research_GivenAValidResearch_ShouldCreate()
        {
            Assert.True(_validResearch.Done);

        }
    }
}
