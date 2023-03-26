using ErrorOr;
using InnerJungle.Application.Authentication.Common;
using MediatR;

namespace InnerJungle.Controllers.Requests
{
    public record RegisterRequest(string FistName, string LastName, string Email, string Password, string Cpf, string UserName) : IRequest<ErrorOr<AuthenticationResult>>;
}
