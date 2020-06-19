using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartRestaurant.Client.Web.Models.Foods
{
    public class FoodListFilterViewModel
    {

        public SelectList Categories { get; set; }
        public string FoodCategoryId { get; set; }
        public string Name { get; set; }
    }
}
