using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.IGetByRestaurantId;
using SmartRestaurant.Client.Web.Models.Menu;
using SmartRestaurant.Resources.Menus.Menu;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
     [Route("admin/menu")]
    [Route("{culture}/admin/menu")]
    public class MenuController : AdminBaseController
    {
        private readonly ILoggerService<MenuController> _log;
        private readonly IGetAllRestaurantsQuery getAllRestaurantsQuery;
        private readonly IGetChefsByRestaurantIdQuery getChefsByRestaurantIdQuery;

        public MenuController(
            IConfiguration configuration, 
            IMailingService mailing, 
            INotifyService notify, 
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<MenuController> log,
            IGetAllRestaurantsQuery getAllRestaurantsQuery,
            IGetChefsByRestaurantIdQuery getChefsByRestaurantIdQuery) : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            this.getAllRestaurantsQuery = getAllRestaurantsQuery ?? throw new ArgumentNullException(nameof(getAllRestaurantsQuery));
            this.getChefsByRestaurantIdQuery = getChefsByRestaurantIdQuery ?? throw new ArgumentNullException(nameof(getChefsByRestaurantIdQuery));
        }

        private SelectList PopulateRestaurants(string restaurantId = null)
        {
            return new SelectList(getAllRestaurantsQuery.Execute(), "Id", "Name", restaurantId);
        }

        [HttpGet]
        public SelectList GetChefsByRestaurantId(string restaurantId,string chefId=null)
        {
            return new SelectList(getChefsByRestaurantIdQuery.Execute(restaurantId), "Id", "Name", chefId);
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
             this.PageBreadcrumb.SetTitle(MenuUtilsResource.HomePageTitle)   
                .AddHome()
                .AddItem(MenuUtilsResource.HomeNavigationTitle, Url.Action("Menu","Index"))
                .Save();
            return View();
        }

        [Route("search")]
        public IActionResult Search()
        {
            this.PageBreadcrumb
               .AddHome()
               .AddItem(MenuUtilsResource.HomeNavigationTitle, Url.Action("Menu", "Index"))
               .AddItem(MenuUtilsResource.SearchNavigationTitle)
               .SetTitle(MenuUtilsResource.SearchPageTitle)
               .Save();
            return View();
        }

        [Route("add")]
        public IActionResult AddMenu()
        {
            this.PageBreadcrumb               
               .AddHome()
               .AddItem(MenuUtilsResource.HomeNavigationTitle, Url.Action("Menu", "Index"))
               .AddItem(MenuUtilsResource.AddMenuNavigationTitle)
               .SetTitle(MenuUtilsResource.AddMenuPageTitle)
               .Save();
            var menu = new MenuViewModel
            {

            };
            return View(menu);
        }
    }
}