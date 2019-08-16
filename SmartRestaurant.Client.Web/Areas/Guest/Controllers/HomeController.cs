using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartRestaurant.Client.Web.Areas.Guest.Controllers
{
    [Route("admin/guest")]
    public class HomeController : GuestBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}