using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Menu.Commands.Create;
using SmartRestaurant.Application.Restaurants.Menu.Queries.GetAllFilterd;
using SmartRestaurant.Application.Restaurants.Menu.Queries.GetAllMenus;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Section.Commands.Create;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.GetChefsByRestaurantIdQuery;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Resources.Section;

namespace SmartRestaurant.Client.Web.Controllers
{
    [Route("section")]
    [Route("{culture}/section")]
    [Authorize(Policy = "RequireAdministratorRole")]

    public class SectionController : AdminBaseController
    {
        private ILoggerService<SectionController> _log;
        private readonly IGetAllMenusQuery _getAllMenusQuery;
        private readonly ICreateSectionCommand _createSectionCommand;
        private IHostingEnvironment _env;

        public SectionController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog,
            ILoggerService<SectionController> log,
            IGetAllRestaurantsQuery getAllRestaurantsQuery,
            IGetChefsByRestaurantIdQuery getChefsByRestaurantIdQuery,
            ICreateMenuCommand createMenuCommand,
            IGetAllMenuFilterdQuery getAllMenuFilterdQuery,
            IGetAllMenusQuery getAllMenusQuery,
            ICreateSectionCommand createSectionCommand,


            UserManager<SRIdentityUser> userManager, IHostingEnvironment env) : base(configuration, mailing, notify,getAllRestaurantsQuery,userManager, baselog)
        {
            _log = log;
            _getAllMenusQuery = getAllMenusQuery;
            _createSectionCommand = createSectionCommand;
            _env = env;
        }

        [Route("")]
        [Route("index")]

        public IActionResult Index()
        {
            this.PageBreadcrumb.SetTitle(SectionUtilsResource.HomePageTitle)
                .AddHome()
                .AddItem(SectionUtilsResource.HomeNavigationTitle, Url.Action("Menu", "Index"))
                .Save();
            return View();
        }

        [Route("add")]
        // [HttpGet]
        public async Task<IActionResult> AddSection()
        {
            PageBreadcrumb
                .AddHome()
                .AddItem(SectionUtilsResource.HomeNavigationTitle, Url.Action("Menu", "Index"))
                .AddItem(SectionUtilsResource.AddSectionNavigationTitle)
                .SetTitle(SectionUtilsResource.AddMenuPageTitle)
                .Save();
            var sectionViewModel = default(SectionViewModel);
            if (User.IsInRole("Admin"))
            {
                sectionViewModel = new SectionViewModel
                {
                    // le cas ou l'utilisateur est un admin on ramene tout les restaurants

                    Restaurants = PopulateRestaurants(null),
     //               Menus = PopulateMenus(null)
                };
                return View(sectionViewModel);
            }
            // si l'utilisateur en cours n'est pas un admin (owner) on ramene son restaurant id
            if (User.IsInRole("Owner"))
            {
                var owner = await GetCurrentOwner();
                sectionViewModel = new SectionViewModel
                {
                    RestaurantId = Guid.Parse(owner.RestaurantId),
                    Menus = PopulateMenus(owner.RestaurantId)
                    
                };
                return View(sectionViewModel);
            }
            throw new InvalidOperationException("utilisateur non autorisé");

        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddSection(SectionViewModel model)
        {
          //  var hostEnveronment = new HostingEnvironment();
            string webRootPath = _env.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            try
            {
                if (files.Any())
                {
                    var file = Path.Combine(webRootPath,@"\uploads\section\"+ files.FirstOrDefault()?.FileName);
                    using (var ms = new MemoryStream())
                    {
                        files[0].CopyTo(ms);
                        var bt = ms.ToArray();
                        await System.IO.File.WriteAllBytesAsync(file, bt);
                    }
                    model.SectionModel.ImageUri = file;

                }

                _createSectionCommand.Execute(model.SectionModel);
            }

            catch (NotValidException ex)
            {
                AddErrorToModelState(ex);
            }

            return RedirectToAction("Index");
            //return View(model);

        }
        [HttpGet]
        [Route("getMenus")]
        public IActionResult GetMenus(string restaurantId)
        {
            return Json(_getAllMenusQuery.Execute(restaurantId));
        }

        protected SelectList PopulateMenus(string restaurantId = null)
        {
            return new SelectList(_getAllMenusQuery.Execute(restaurantId), "Id", "Name", restaurantId);
        }


    }
}