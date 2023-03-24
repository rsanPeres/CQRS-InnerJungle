using ErrorOr;
using InnerJungle.Application.Authentication.Common;
using MediatR;

namespace InnerJungle.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
