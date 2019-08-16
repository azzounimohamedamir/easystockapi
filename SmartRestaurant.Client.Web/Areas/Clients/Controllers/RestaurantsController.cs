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
    [Route("clients/restaurants")]
    public class RestaurantsController : ClientBaseController
    {
        public RestaurantsController(IConfiguration configuration,
                                     IMailingService mailing,
                                     INotifyService notify,
                                     ILoggerService<ClientBaseController> baselog,
                                     IGetRetaurantBySlugUrlQuery getRetaurantBySlugUrlQuery) : base(configuration, mailing, notify, baselog, getRetaurantBySlugUrlQuery)
        {
        }
        [Route("")]
        [Route("/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("details")]
        public IActionResult Details()
        {
            return View();
        }
    }
}