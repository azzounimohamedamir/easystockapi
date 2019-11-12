using System;
using System.Threading.Tasks;
using DataTables.AspNetCore.Mvc.Binder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Create;
using SmartRestaurant.Application.Restaurants.Menu.Queries.GetAllFilterd;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetChefsByRestaurantIdQuery;
using SmartRestaurant.Client.Web.Models.Menu;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Resources.Menus.Menu;

namespace SmartRestaurant.Client.Web.Controllers
{
     [Route("menu")]
    [Route("{culture}/menu")]
     [Authorize(Policy = "RequireAdministratorRole")]
    public class MenuController : AdminBaseController
    {
        private readonly ILoggerService<MenuController> _log;
        private readonly IGetAllRestaurantsQuery _getAllRestaurantsQuery;
        private readonly IGetChefsByRestaurantIdQuery _getChefsByRestaurantIdQuery;
        private readonly ICreateMenuCommand _createMenuCommand;
        private readonly IGetAllMenuFilterdQuery _getAllMenuFilterdQuery;
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
            IGetAllMenuFilterdQuery getAllMenuFilterdQuery,
            UserManager<SRIdentityUser> userManager) : base(configuration, mailing, notify, baselog)
        {
            _log = log;
            _getAllRestaurantsQuery = getAllRestaurantsQuery ?? throw new ArgumentNullException(nameof(getAllRestaurantsQuery));
            _getChefsByRestaurantIdQuery = getChefsByRestaurantIdQuery ?? throw new ArgumentNullException(nameof(getChefsByRestaurantIdQuery));
            _createMenuCommand = createMenuCommand;
            _getAllMenuFilterdQuery = getAllMenuFilterdQuery;
            _userManager = userManager;
        }

        private SelectList PopulateRestaurants(string restaurantId = null)
        {
            return new SelectList(_getAllRestaurantsQuery.Execute(), "Id", "Name", restaurantId);
        }

        [HttpGet]
        public SelectList GetChefsByRestaurantId(string restaurantId,string chefId=null)
        {
            return new SelectList(_getChefsByRestaurantIdQuery.Execute(restaurantId), "Id", "Name", chefId);
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
       // [Authorize(Roles = "Admin,Owner")]
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

        [Route("getAll")]
        [HttpGet]
        [Authorize(Roles = "Admin,Owner")]
        public async Task<IActionResult> Get([DataTablesRequest] DataTablesRequest dataRequest)
        {
            var restarantId = default(Guid?);
            if (User.IsInRole("Owner"))
            {
                var owner = await GetCurentowner();
                if (owner != null)
                    restarantId = Guid.Parse(owner.RestaurantId);
            }

            var result = _getAllMenuFilterdQuery
                .Execute(Convert.ToInt32(dataRequest.Start),
                    Convert.ToInt32(dataRequest.Length),
                    dataRequest.Search?.Value,
                    dataRequest.Orders,
                    restarantId);
            return Json(result.Data.ToDataTablesResponse(dataRequest, result.RecordsTotal, result.RecordsFilterd));

        }


        [Route("add")]
       // [HttpGet]
        public async Task<IActionResult> AddMenu()
        {
            PageBreadcrumb               
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
                var owner = await GetCurentowner();
                menu = new MenuViewModel
                {
                    RestaurantId = Guid.Parse(owner.RestaurantId)
                };
                return View(menu);
            }
            throw new InvalidOperationException("utilisateur non autorisé"); 

        }

        private async Task<SRIdentityUser> GetCurentowner()
        {
            var owner = await _userManager.GetUserAsync(User).ConfigureAwait(false);
            return owner;
        }

        [Route("add")]
        [HttpPost]
       // [Authorize(Roles = "Admin,Owner")]
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