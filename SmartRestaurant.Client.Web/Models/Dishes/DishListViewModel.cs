using SmartRestaurant.Application.Dishes.Dishes.Queries.Models;
using SmartRestaurant.Client.Web.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class DishListViewModel
    {
        public PaginatedList<DishItemModel> List { get; set; }
        public DishListFilterViewModel Filter { get; set; }
    }
}
