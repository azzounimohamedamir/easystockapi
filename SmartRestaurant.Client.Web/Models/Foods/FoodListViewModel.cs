using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Client.Web.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Foods
{
    public class FoodListViewModel
    {
        public FoodListFilterViewModel Filter { get; set; }
        public PaginatedList<FoodItemModel> List { get; set; }        
    }
}
