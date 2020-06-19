using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;

namespace SmartRestaurant.Client.Web.Controllers
{
    // [Area("Admin")]
    [Route("commun/kitchens")]
    public class KitchensController : AdminBaseController
    {
        public KitchensController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog)
            : base(configuration, mailing, notify, baselog)
        {
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}