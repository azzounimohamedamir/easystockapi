using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;

namespace SmartRestaurant.Client.Web.Controllers
{
   // [Area("Admin")]
    [Route("dishesandingredients")]
    [Route("{restaurant}/dishesandingredients")]
    public class IngredientsController : AdminBaseController
    {
        public IngredientsController(
            IConfiguration configuration, 
            IMailingService mailing, 
            INotifyService notify, 
            ILoggerService<AdminBaseController> baselog) 
            : base(configuration, mailing, notify, baselog)
        {
        }

        [Route("ingredients")]        
        public IActionResult Ingredients()
        {
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }
    }
}