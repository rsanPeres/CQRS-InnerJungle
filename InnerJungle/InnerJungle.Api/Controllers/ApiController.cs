using ErrorOr;
using InnerJungle.Common.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnerJungle.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            HttpContext.Items[HttpContextItemKeys.Errors] = errors;
            var firstError = errors[0];

            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode : statusCode, title : firstError.Description);
        }
    }
}
