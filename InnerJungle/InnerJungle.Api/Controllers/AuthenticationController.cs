using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnerJungle.Controllers
{
    [ApiController]
    [Route("v1/Auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}
