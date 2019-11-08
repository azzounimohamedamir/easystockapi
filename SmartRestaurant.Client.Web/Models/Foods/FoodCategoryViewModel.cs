using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.FoodCategories.Commands;
using SmartRestaurant.Application.FoodCategories.Commands.Update;
using SmartRestaurant.Client.Web.Models.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Foods
{
    //public abstract class BaseViewModel
    //{
    //    public string Action { get; set; }
    //}

    public class FoodCategoryViewModel        
    {        
        public FoodCategoryViewModel()
        {           
            Picture = new FileViewModel();
            Parents = new SelectListViewModel();            
        }
        public string ParentId { get; set; }
        public SelectListViewModel Parents { get; set; }
        public FileViewModel Picture { get; set; }

        public UpdateFoodCategoryModel UpdateModel { get; set; }
        public CreateFoodCategoryModel CreateModel { get; set; }
    }
}
