using InnerJungle.Domain.Commands;
using InnerJungle.Domain.Entities;
using InnerJungle.Domain.Handlers;
using InnerJungle.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InnerJungle.Api.Controllers
{
    [ApiController]
    [Route("v1/researches")]
    public class ResearchController : ControllerBase
    {
        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Research> GetAll([FromServices]IResearchRepository repository) 
        {
            return repository.GetAll("inner");
        }

        [HttpGet]
        [Route("getAllDone")]
        public IEnumerable<Research> GetAllDone([FromServices] IResearchRepository repository)
        {
            return repository.GetAllDone("inner");
        }

        [HttpGet]
        [Route("getAllUndone")]
        public IEnumerable<Research> GetAllUndone([FromServices] IResearchRepository repository)
        {
            return repository.GetAllUndone("inner");
        }

        [HttpGet]
        [Route("undone/today")]
        public IEnumerable<Research> GetInactiveForToday([FromServices] IResearchRepository repository)
        {
            return repository.GetByPeriod("inner", DateTime.Now.Date, false);
        }

        [HttpGet]
        [Route("done/today")]
        public IEnumerable<Research> GetActiveforToday([FromServices] IResearchRepository repository)
        {
            return repository.GetByPeriod("inner", DateTime.Now.Date, true);
        }

        [HttpPost]
        [Route("create")]
        public GenericCommandResult Create([FromBody] CreateResearchCommand command, [FromServices] CreateResearchHandler handler)
        {
            command.User = "innerJungle";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("update")]
        public GenericCommandResult Update([FromBody]UpdateResearchCommand command, [FromServices] UpdateResearchHandler handler)
        {
            command.User = "inner";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("markAsDone")]
        public GenericCommandResult MarkAsDone([FromBody] MarkResearchAsDoneCommand command, [FromServices] ResearchDoneHandler handler)
        {
            command.User = "inner";
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
