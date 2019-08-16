using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetBySlugUrl;

namespace SmartRestaurant.Client.Web.Areas.Clients.Controllers
{
    [Area("Clients")]
    [Route("clients")]
    [Route("clients/home")]
    public class HomeController : ClientBaseController
    {
        private readonly ILoggerService<HomeController> log;
        private readonly IGetRetaurantBySlugUrlQuery getRetaurantBySlugUrlQuery;

        public HomeController(IConfiguration configuration,
                              IMailingService mailing,
                              INotifyService notify,
                              ILoggerService<ClientBaseController> baselog,                              
                              IGetRetaurantBySlugUrlQuery getRetaurantBySlugUrlQuery,
                              ILoggerService<HomeController> log) : base(configuration, mailing, notify, baselog, getRetaurantBySlugUrlQuery)
        {
            this.log = log;            
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}