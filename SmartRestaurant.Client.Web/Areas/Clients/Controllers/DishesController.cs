using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetBySlugUrl;
using SmartRestaurant.Resources.Dishes.Dish;
using SmartRestaurant.Resources.Menus.Menu;

namespace SmartRestaurant.Client.Web.Areas.Clients.Controllers
{
    [Area("Clients")]
    [Route("clients/dishes")]
    public class DishesController : ClientBaseController
    {
        private readonly ILoggerService<MenusController> log;

        public DishesController(IConfiguration configuration,
                                IMailingService mailing,
                                INotifyService notify,
                                ILoggerService<ClientBaseController> baselog,
                                IGetRetaurantBySlugUrlQuery getRetaurantBySlugUrlQuery,
                                ILoggerService<MenusController> log) : base(configuration, mailing, notify, baselog, getRetaurantBySlugUrlQuery)
        {
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public IActionResult Index()
        {
            this.PageBreadcrumb
                .AddHome()
                .AddOptionalItem(Restaurant?.Name, Url.Action("Details", "Restaurants", new { restaurant = Restaurant?.SlugUrl, area = areaName }))
                .AddItem(DishUtilsResource.HomeNavigationTitle)
                .SetTitle(DishUtilsResource.HomePageTitle)
                .Save();
            return View();
        }
    }
}