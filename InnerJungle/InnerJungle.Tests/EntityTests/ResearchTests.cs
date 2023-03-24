using AutoFixture;
using InnerJungle.Domain.Entities;
using Xunit;

namespace InnerJungle.Tests.EntityTests
{
    public class ResearchTests
    {
        private readonly Fixture _fixture;
        private readonly User user;
        private readonly Institution institution;
        private readonly Eletrode eletrode;
        private readonly Research _validResearch;
        private readonly Research _invalidResearch;

        public ResearchTests(Fixture fixture)
        {
            _fixture = fixture;
            user = _fixture.Create<User>();
            institution = _fixture.Create<Institution>();
            eletrode = _fixture.Create<Eletrode>();
        }

        [Fact]
        public void Research_GivenAValidResearch_ShouldCreate()
        {
            Assert.True(_validResearch.Done);

        }
    }
}
