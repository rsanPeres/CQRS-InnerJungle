using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Enums;
using Xunit;

namespace InnerJungle.Tests.CommandTests
{
    public class CreateResearchCommandTests
    {
        private readonly CreateResearchCommand _invalidCommand = new CreateResearchCommand("", true, new User("", "", RoleNames.Default, "", "", "", ""));
        private readonly CreateResearchCommand _validCommand = new CreateResearchCommand("inner jungle", true, new User("", "", RoleNames.Default, "", "", "", ""));

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
