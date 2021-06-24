using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/healthcheck")]
    [ApiController]
    public class HealthCheckController : ApiController
    {
        [HttpGet]
        public IActionResult IsOk()
        {
            return Ok();
        }
    }
}