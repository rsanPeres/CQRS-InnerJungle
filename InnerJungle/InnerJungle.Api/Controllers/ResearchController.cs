using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Enums;
using InnerJungle.Domain.Handlers;
using InnerJungle.Domain.Interfaces;
using InnerJungle.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace InnerJungle.Api.Controllers
{
    [ApiController]
    [Route("v1/researches")]
    [Authorize]
    public class ResearchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Research> GetAll([FromServices]IResearchRepository repository) 
        {
            var name = User.Claims.FirstOrDefault(x => x.Type =="user_id")?.Value;
            var user = new User(name, "", RoleNames.Default, "");
            return repository.GetAll(user);
        }

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

        [HttpPost]
        [Route("create")]
        public GenericCommandResult Create([FromBody] CreateResearchCommand command, [FromServices] CreateResearchHandler handler)
        {
            var user = new User("", "", RoleNames.Default, "");
         
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("update")]
        public GenericCommandResult Update([FromBody]UpdateResearchCommand command, [FromServices] UpdateResearchHandler handler)
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
        }
    }
}
