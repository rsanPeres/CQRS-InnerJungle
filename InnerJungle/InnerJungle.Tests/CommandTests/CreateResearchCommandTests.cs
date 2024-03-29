﻿using InnerJungle.Application.Researches.Commands;
using Xunit;

namespace InnerJungle.Tests.CommandTests
{
    public class CreateResearchCommandTests
    {
        private readonly CreateResearchCommand _invalidCommand = new CreateResearchCommand();
        private readonly CreateResearchCommand _validCommand = new CreateResearchCommand();

        public CreateResearchCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [Fact]
        public void CreateResearchCommand_GivenAnInvalidCommand()
        {
            Assert.False(_invalidCommand.Validate().IsValid);
        }

        [Fact]
        public void CreateResearchCommand_GivenAnValidCommand()
        {
            Assert.True(_validCommand.Validate().IsValid);
        }
    }
}
