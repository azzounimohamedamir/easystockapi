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
            var value = "I am logged in";
            return Ok(value);
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
