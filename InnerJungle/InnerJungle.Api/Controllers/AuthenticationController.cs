using InnerJungle.Application.Authentication.Commands.Register;
using InnerJungle.Application.Authentication.Common;
using InnerJungle.Application.Authentication.Queries.Login;
using InnerJungle.Controllers.Requests;
using InnerJungle.Controllers.Responses;
using InnerJungle.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnerJungle.Controllers
{
    [Route("v1/Auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FistName, request.LastName, request.Email, request.Password);
            var authResult = await _mediator.Send(command);
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == ErrorsAuthentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        private static AthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token
                );
        }
    }
}
