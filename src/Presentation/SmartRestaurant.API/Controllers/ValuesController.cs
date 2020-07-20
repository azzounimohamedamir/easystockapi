using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult GetValues()
        {
            var values = new[] { "1", "2", "3" };
            return Ok(values);
        }

        [Authorize(Roles = "User")]
        [HttpGet("user")]
        public IActionResult GetValue()
        {
            var value = "I am user";
            return Ok(value);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminValue()
        {
            var value = "I am admin";
            return Ok(value);
        }
    }
}
