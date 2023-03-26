using Microsoft.AspNetCore.Mvc;

namespace InnerJungle.Controllers
{
    [Route("innerJungleController")]
    public class InnerJungleController : ApiController
    {
        public InnerJungleController(ILogger<ApiController> logger) : base(logger)
        {
        }

        [HttpGet]
        public IActionResult ListResearch()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
