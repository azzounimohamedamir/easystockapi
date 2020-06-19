using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Dishes.DishFamillies.Commands.Create;
using SmartRestaurant.Client.Web.Models.Utils;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class CreateDishFamilyViewModel
    {
        public CreateDishFamilyViewModel()
        {
            Picture = new FileViewModel();
            Parents = new SelectListViewModel();
        }
        public string ParentId { get; set; }
        public SelectListViewModel Parents { get; set; }
        public FileViewModel Picture { get; set; }
        public SelectList Restaurants { get; set; }
        public CreateDishFamilyModel CreateModel { get; set; }
    }
}
