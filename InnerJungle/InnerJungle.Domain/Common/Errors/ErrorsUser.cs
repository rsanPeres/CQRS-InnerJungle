using ErrorOr;

namespace InnerJungle.Domain.Common.Errors
{
    public static class ErrorsUser
    {
        public static Error DuplicateEmail = Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use");
    }
}

