using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Create;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Update;
using SmartRestaurant.Client.Web.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class UpdateDishFamilyViewModel
    {
        public UpdateDishFamilyViewModel()
        {
            Picture = new FileViewModel();
            Parents = new SelectListViewModel();
        }
        public string ParentId { get; set; }
        public SelectListViewModel Parents { get; set; }
        public SelectList Restaurants { get; set; }
        public FileViewModel Picture { get; set; }

        public UpdateDishFamilyModel UpdateModel { get; set; }        
    }
}
