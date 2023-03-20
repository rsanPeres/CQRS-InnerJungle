using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Enums;
using InnerJungle.Domain.Handlers;
using InnerJungle.Domain.Interfaces;
using InnerJungle.Domain.Interfaces.Repositories;
using InnerJungle.Tests.Repositories;
using Moq;
using Xunit;

namespace InnerJungle.Tests.HandlerTests
{
    public class CreateResearchHandlerTests
    {
        private readonly CreateResearchCommand _invalidCommand = new CreateResearchCommand("", true, new User("", "", RoleNames.Default, "","", "", ""));
        private readonly CreateResearchCommand _validCommand = new CreateResearchCommand("inner jungle", true, new User("", "", RoleNames.Default, "", "", "", ""));
        private readonly CreateResearchHandler _handler;
        private readonly Mock<IResearchRepository> _repository;

        //public CreateResearchHandlerTests()
        //{
        //    _repository = new Mock<IResearchRepository>();
        //    _handler = new CreateResearchHandler(new FakeResearchRepository());
        //}

        //[Fact]
        //public void test()
        //{
        //    var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        //    Assert.NotNull(result);
        //    Assert.False(result.Success);
        //}

        //[Fact]
        //public void testvalid()
        //{
        //    var result = (GenericCommandResult)_handler.Handle(_validCommand);
        //    Assert.NotNull(result);
        //    Assert.True(result.Success);
        //}
    }
}
