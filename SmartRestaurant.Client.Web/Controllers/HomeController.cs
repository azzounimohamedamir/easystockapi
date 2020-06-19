using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Resources.UI.Areas.Admin.Breadcrumb;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Controllers
{
    //[Area("Admin")]
    //[Route("admin")]

    //[Route("admin/home")]
    [Authorize(Policy = "RequireAdministratorRole")]
    public class HomeController : AdminBaseController
    {
        private readonly ILoggerService<HomeController> _log;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<HomeController> log,
            IHostingEnvironment hostingEnvironment) : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            _hostingEnvironment = hostingEnvironment;
        }

        private List<SelectListItem> PopulateDemo(string id)
        {
            var result = new List<SelectListItem>();

            for (var index = 1; index <= 10; index++)
            {
                result.Add(new SelectListItem
                {
                    Text = $"{id} Item {index}",
                    Value = $"{id}Item{index}"
                });
            }
            return result;
        }


        public IActionResult Index()
        {
            PageBreadcrumb
                .AddItem(BreadcrumbResource.Home)
                .SetTitle(BreadcrumbResource.Administration)
                .Save();


            return View();
        }


        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            PageBreadcrumb
                .AddHome()
                .SetTitle(BreadcrumbResource.Dashboard)
                .Save();
            return View();
        }


        [Route("LoadTest")]
        public IActionResult LoadTest(string id)
        {
            var items = new List<SelectListItem>{
                new SelectListItem
                {
                    Value="01",Text="Text 01"
                },
                new SelectListItem
                {
                    Value="02",Text="Text 02"
                }
            };
            var select = new SelectList(items, "Value", "Text");
            return PartialView("_Test", select);
        }

        [Route("Picture")]
        public IActionResult Picture()
        {
            PictureViewModel model = new PictureViewModel();
            return View(model);
        }


        [Route("Cheff")]
        public IActionResult Cheff()
        {
            return View();
        }
    }
}