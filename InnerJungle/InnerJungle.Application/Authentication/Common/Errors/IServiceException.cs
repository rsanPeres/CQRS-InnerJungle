using System.Net;

namespace InnerJungle.Application.Authentication.Common.Errors
{
    public interface IServiceException
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}
