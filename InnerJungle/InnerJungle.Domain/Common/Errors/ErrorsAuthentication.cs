using ErrorOr;

namespace InnerJungle.Domain.Common.Errors
{
    public static class ErrorsAuthentication
    {
        public static Error InvalidCredentials = Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid credentials");
    }
}
