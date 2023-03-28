using InnerJungle.Application.Researches.Commands;
using InnerJungle.Domain.Interfaces.Repositories;
using Moq;

namespace InnerJungle.Tests.HandlerTests
{
    public class CreateResearchHandlerTests
    {
        private readonly CreateResearchCommand _invalidCommand = new CreateResearchCommand();
        private readonly CreateResearchCommand _validCommand = new CreateResearchCommand();
        private readonly CreateResearchCommandHandler _handler;
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
