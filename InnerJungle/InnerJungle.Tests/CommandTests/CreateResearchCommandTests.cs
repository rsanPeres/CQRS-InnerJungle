using InnerJungle.Domain.Commands;
using Xunit;

namespace InnerJungle.Tests.CommandTests
{
    public class CreateResearchCommandTests
    {
        private readonly CreateResearchCommand _invalidCommand = new CreateResearchCommand("", true, "");
        private readonly CreateResearchCommand _validCommand = new CreateResearchCommand("inner jungle", true, "inner");

        public CreateResearchCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [Fact]
        public void CreateResearchCommand_GivenAnInvalidCommand()
        {
            Assert.False(_invalidCommand.IsValid);
        }

        [Fact]
        public void CreateResearchCommand_GivenAnValidCommand()
        {
            Assert.True(_validCommand.IsValid);
        }
    }
}
