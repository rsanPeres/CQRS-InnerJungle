namespace InnerJungle.Controllers.Responses
{
    public record AthenticationResponse(Guid Id, string FirstName, string LastName, string Email, string Token);
}
