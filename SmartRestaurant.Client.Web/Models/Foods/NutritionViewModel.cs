using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Foods.Models;

namespace SmartRestaurant.Client.Web.Models.Foods
{
    public class NutritionViewModel
    {
        public NutritionViewModel(SelectList units)
        {
            Units = units;
        }
        public NutritionModel Nutrition { get; set; }
        public SelectList Units { get; set; }
    }

}
