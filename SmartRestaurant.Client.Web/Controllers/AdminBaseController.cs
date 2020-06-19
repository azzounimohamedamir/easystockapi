using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Resources.Foods.FoodCategories;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Controllers
{
    //[Area("Admin")]
    //[Authorize(Roles = "Developper")]  
    public class AdminBaseController : SRBaseController
    {
        private readonly IGetAllRestaurantsQuery _getAllRestaurantsQuery;
        private readonly UserManager<SRIdentityUser> _userManager;
        private readonly ILoggerService<AdminBaseController> _baselog;

        public AdminBaseController(
            IConfiguration configuration,
            IMailingService mailing,
            INotifyService notify,
            ILoggerService<AdminBaseController> baselog) : base(configuration, mailing, notify)
        {
            _baselog = baselog;
            PageBreadcrumb = new BreadcrumbViewModel { Controller = this };
        }

        public AdminBaseController(IConfiguration configuration,
            IMailingService mailing,
        INotifyService notify,
            IGetAllRestaurantsQuery getAllRestaurantsQuery,
            UserManager<SRIdentityUser> userManager, ILoggerService<AdminBaseController> baselog) : base(configuration, mailing, notify)
        {
            _getAllRestaurantsQuery = getAllRestaurantsQuery;
            _userManager = userManager;
            _baselog = baselog;
            PageBreadcrumb = new BreadcrumbViewModel { Controller = this };
        }

        protected SelectListViewModel BuildSelectListViewModelForFoodsCategories(SelectList items,
            string target = "ParentId")
        {
            return new SelectListViewModel
            {
                ActionUrl = Url.Action("LoadItemChilds", "FoodsCategories"),
                TargetId = target,
                EmptyOptionText = FoodCategoryResource.ParentId,
                Items = items,
            };
        }
        protected SelectList PopulateRestaurants(string restaurantId = null)
        {
            return new SelectList(_getAllRestaurantsQuery.Execute(), "Id", "Name", restaurantId);
        }
        protected async Task<SRIdentityUser> GetCurrentOwner()
        {
            return await _userManager.GetUserAsync(User).ConfigureAwait(false);
        }


    }
}