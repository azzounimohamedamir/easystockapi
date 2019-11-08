using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Create;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Models;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetChefsByRestaurantIdQuery;
using SmartRestaurant.Client.Web.Models.Menu;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Resources.Menus.Menu;

namespace SmartRestaurant.Client.Web.Controllers
{
     [Route("menu")]
    [Route("{culture}/menu")]
    public class MenuController : AdminBaseController
    {
        private readonly ILoggerService<MenuController> _log;
        private readonly IGetAllRestaurantsQuery getAllRestaurantsQuery;
        private readonly IGetChefsByRestaurantIdQuery getChefsByRestaurantIdQuery;
        private readonly ICreateMenuCommand _createMenuCommand;
        private readonly UserManager<SRIdentityUser> _userManager;
        public MenuController(
            IConfiguration configuration, 
            IMailingService mailing, 
            INotifyService notify, 
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<MenuController> log,
            IGetAllRestaurantsQuery getAllRestaurantsQuery,
            IGetChefsByRestaurantIdQuery getChefsByRestaurantIdQuery, 
            ICreateMenuCommand createMenuCommand, 
            UserManager<SRIdentityUser> userManager) : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            this.getAllRestaurantsQuery = getAllRestaurantsQuery ?? throw new ArgumentNullException(nameof(getAllRestaurantsQuery));
            this.getChefsByRestaurantIdQuery = getChefsByRestaurantIdQuery ?? throw new ArgumentNullException(nameof(getChefsByRestaurantIdQuery));
            _createMenuCommand = createMenuCommand;
            _userManager = userManager;
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
        [Authorize(Roles = "Admin,Owner")]
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

        [Authorize(Roles = "Admin,Owner")]
        [Route("add")]
        public async Task<IActionResult> AddMenu()
        {
            this.PageBreadcrumb               
               .AddHome()
               .AddItem(MenuUtilsResource.HomeNavigationTitle, Url.Action("Menu", "Index"))
               .AddItem(MenuUtilsResource.AddMenuNavigationTitle)
               .SetTitle(MenuUtilsResource.AddMenuPageTitle)
               .Save();
            var menu = default(MenuViewModel);
            // le cas ou l'utilisateur est un admin on ramene tout les restaurants
            if (User.IsInRole("Admin"))
            {
                menu = new MenuViewModel
                {
                    Restaurants = PopulateRestaurants(null)
                };
                return View(menu);
            }
            // si l'utilisateur en cours n'est pas un admin (owner) on ramene son restaurant id
            if (User.IsInRole("Owner"))
            {
                var owner = await _userManager.GetUserAsync(User).ConfigureAwait(false);
                menu = new MenuViewModel
                {
                    RestaurantId = Guid.Parse(owner.RestaurantId)
                };
                return View(menu);
            }
            throw new InvalidOperationException("utilsateur non autorisé"); 

        }
        [Route("add")]
        [HttpPost]
        [Authorize(Roles = "Admin,Owner")]
        public IActionResult AddMenu(MenuViewModel model)
        {
            try
            {
                //au  cas ou l'utlisateur en cours est le propriétaire du restaurant
                if (model.RestaurantId.HasValue && User.IsInRole("Owner"))
                    model.MenuModel.RestaurantId = model.RestaurantId.ToString();
                else if(!model.RestaurantId.HasValue && User.IsInRole("Owner"))
                    throw new ArgumentNullException(nameof(model.RestaurantId));
                _createMenuCommand.Execute(model.MenuModel);
            }

            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }

            return RedirectToAction("Index");
        }
    }
}