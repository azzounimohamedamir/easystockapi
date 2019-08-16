using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetBySlugUrl;
using SmartRestaurant.Client.Web.Controllers;
using SmartRestaurant.Client.Web.Models;
using SmartRestaurant.Client.Web.Models.Utils;
using SmartRestaurant.Persistence.Mailing;
using SmartRestaurant.Resources.Foods.FoodCategories;

namespace SmartRestaurant.Client.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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