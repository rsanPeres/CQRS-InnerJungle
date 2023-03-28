using InnerJungle.Domain.Commands.Contracts;

namespace InnerJungle.Controllers.Responses
{
    public record AsyncEntityResponse(Guid CommandId, Object Data);
}
