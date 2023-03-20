using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Commands.Contracts;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Handlers;
using InnerJungle.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnerJungle.Api.Controllers
{
    [ApiController]
    [Route("v1/researches")]
    public class ResearchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResearchController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Research> GetAll([FromServices] IResearchRepository repository)
        {

            return new List<Research>();
        }
        /*
        [HttpGet]
        [Route("getAllDone")]
        public IEnumerable<Research> GetAllDone([FromServices] IResearchRepository repository)
        {
            var name = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var user = new User(name, "", RoleNames.Default, "");
            return repository.GetAllDone(user);
        }

        [HttpGet]
        [Route("getAllUndone")]
        public IEnumerable<Research> GetAllUndone([FromServices] IResearchRepository repository)
        {
            var name = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var user = new User(name, "", RoleNames.Default, "");

            return repository.GetAllUndone(user);
        }

        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<Research> GetInactiveForToday([FromServices] IResearchRepository repository)
        {
            var name = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var user = new User(name, "", RoleNames.Default, "");

            return repository.GetByPeriod(user, DateTime.Now.Date, false);
        }

        [HttpGet]
        [Route("done/today")]
        public IEnumerable<Research> GetActiveforToday([FromServices] IResearchRepository repository)
        {
            var name = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var user = new User(name, "", RoleNames.Default, "");

            return repository.GetByPeriod(user, DateTime.Now.Date, true);
        }
        */
        [HttpPost]
        [Route("create")]
        public async Task<GenericCommandResult> Create([FromBody] CreateResearchCommand command, [FromServices] CreateResearchHandler handler)
        {
            var user = new User("", "", Domain.Enums.RoleNames.Default, "", "", "", "");

            return (GenericCommandResult)handler.Handle(command).Result;
        }
        /*
        [HttpPut]
        [Route("update")]
        public GenericCommandResult Update([FromBody] UpdateResearchCommand command, [FromServices] UpdateResearchHandler handler)
        {
            command.User = new User("", "", RoleNames.Default, "");
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("markAsDone")]
        public GenericCommandResult MarkAsDone([FromBody] MarkResearchAsDoneCommand command, [FromServices] ResearchDoneHandler handler)
        {
            command.User = new User("", "", RoleNames.Default, "");
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("markAsUndone")]
        public GenericCommandResult MarkAsUndone([FromBody] MarkResearchAsDoneCommand command, [FromServices] ResearchDoneHandler handler)
        {
            command.User = new User("", "", RoleNames.Default, "");
            return (GenericCommandResult)handler.Handle(command);
        }*/
    }
}
