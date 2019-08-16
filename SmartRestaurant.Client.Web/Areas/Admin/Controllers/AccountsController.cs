using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}