using SmartRestaurant.Application.FoodCategories.Commands;
using SmartRestaurant.Application.FoodCategories.Commands.Update;
using SmartRestaurant.Client.Web.Models.Utils;

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
