using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Foods.Models;
using SmartRestaurant.Client.Web.Models.Utils;

namespace SmartRestaurant.Client.Web.Models.Foods
{
    public class FoodViewModel
    {
        public FoodViewModel()
        {
            Picture = new FileViewModel();
            Categories = new SelectListViewModel();
        }
        public string Action { get; set; } = "Add";
        //public string FoodCategoryId { get; set; }
        public SelectListViewModel Categories { get; set; }
        public FileViewModel Picture { get; set; }
        public FoodModel FoodModel { get; set; }
        public NutritionModel Nutrition { get; set; }
        public SelectList Units { get; set; }
    }



}
