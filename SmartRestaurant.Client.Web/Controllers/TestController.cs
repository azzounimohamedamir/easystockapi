using Microsoft.AspNetCore.Mvc;

namespace SmartRestaurant.Client.Web.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}