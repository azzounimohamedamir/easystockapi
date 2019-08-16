using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Resources.UI.Shared;

namespace SmartRestaurant.Client.Web.Controllers
{
    
    [Route("home")]
    public class HomeController : SRBaseController
    {
        private readonly ILoggerService<HomeController> _log;

        public HomeController(
            IConfiguration configuration, 
            IMailingService mailing, 
            INotifyService notify,
            ILoggerService<HomeController> log) : base(configuration, mailing, notify)
        {
            _log = log;
        }

        public IActionResult Index()
        {
            
            ViewBag.Test = SharedResource.Application_Name;
            //var model = new TestViewModel();
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(TestViewModel vm)
        //{
        //    return View(vm);
        //}

     
    }
}
