using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Client.Web.Models.Utils;

namespace SmartRestaurant.Client.Web.Models.Foods
{
    public class FoodListViewModel
    {
        public FoodListFilterViewModel Filter { get; set; }
        public PaginatedList<FoodItemModel> List { get; set; }
    }
}
