using Microsoft.AspNetCore.Mvc;

namespace InnerJungle.Controllers
{
    [Route("innerJungleController")]
    public class InnerJungleController : ApiController
    {
        [HttpGet]
        public IActionResult ListResearch()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
