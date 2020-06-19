using SmartRestaurant.Application.Dishes.Dishes.Queries.Models;
using SmartRestaurant.Client.Web.Models.Utils;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class DishListViewModel
    {
        public PaginatedList<DishItemModel> List { get; set; }
        public DishListFilterViewModel Filter { get; set; }
    }
}
