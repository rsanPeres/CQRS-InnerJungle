using FluentResults;

namespace InnerJungle.Application.Common.Errors
{
    public class DuplicateEmailException : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => "Email already exists";

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
