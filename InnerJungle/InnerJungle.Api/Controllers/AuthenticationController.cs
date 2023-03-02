using InnerJungle.Application.Services.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnerJungle.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var command = new RegisterCommand();
            AuthenticationResult authResult = _mediator.Send(command);

            return Ok(authResult);
        }
    }
}
