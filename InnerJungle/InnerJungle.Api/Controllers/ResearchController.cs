using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Handlers;
using InnerJungle.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnerJungle.Api.Controllers
{
    [ApiController]
    [Route("v1/researches")]
    [Authorize]
    public class ResearchController : ControllerBase
    {
        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Research> GetAll([FromServices]IResearchRepository repository) 
        {
            var user = User.Claims.FirstOrDefault(x => x.Type =="user_id")?.Value;
            return repository.GetAll(user);
        }

        [HttpGet]
        [Route("getAllDone")]
        public IEnumerable<Research> GetAllDone([FromServices] IResearchRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            return repository.GetAllDone(user);
        }

        [HttpGet]
        [Route("getAllUndone")]
        public IEnumerable<Research> GetAllUndone([FromServices] IResearchRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            return repository.GetAllUndone(user);
        }

        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<Research> GetInactiveForToday([FromServices] IResearchRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            return repository.GetByPeriod(user, DateTime.Now.Date, false);
        }

        [HttpGet]
        [Route("done/today")]
        public IEnumerable<Research> GetActiveforToday([FromServices] IResearchRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

            return repository.GetByPeriod(user, DateTime.Now.Date, true);
        }

        [HttpPost]
        [Route("create")]
        public GenericCommandResult Create([FromBody] CreateResearchCommand command, [FromServices] CreateResearchHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            ;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("update")]
        public GenericCommandResult Update([FromBody]UpdateResearchCommand command, [FromServices] UpdateResearchHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("markAsDone")]
        public GenericCommandResult MarkAsDone([FromBody] MarkResearchAsDoneCommand command, [FromServices] ResearchDoneHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("markAsUndone")]
        public GenericCommandResult MarkAsUndone([FromBody] MarkResearchAsDoneCommand command, [FromServices] ResearchDoneHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
