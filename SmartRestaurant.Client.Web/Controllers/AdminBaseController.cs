using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Resources.Foods.FoodCategories;

namespace SmartRestaurant.Client.Web.Controllers
{
    //[Area("Admin")]
    //[Authorize(Roles = "Developper")]  
    public class AdminBaseController : SRBaseController
    {      
        
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

        protected SelectListViewModel BuildSelectListViewModelForFoodsCategories(SelectList items,string target="ParentId")
        {
            return new SelectListViewModel
            {
                ActionUrl = Url.Action("LoadItemChilds", "FoodsCategories"),
                TargetId = target,
                EmptyOptionText = FoodCategoryResource.ParentId,
                Items = items,
            };
        }

        
    }
}