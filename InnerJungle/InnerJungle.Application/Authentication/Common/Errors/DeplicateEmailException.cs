using System.Net;

namespace InnerJungle.Application.Authentication.Common.Errors
{
    public class DeplicateEmailException : Exception, IServiceException
    {
        public DeplicateEmailException(string message) : base(message) 
        {
        }

        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Email already exists";
    }
}
