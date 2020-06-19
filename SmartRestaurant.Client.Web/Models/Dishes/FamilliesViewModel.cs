using SmartRestaurant.Application.Dishes.DishFamillies.Queries.Models;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class FamilliesViewModel
    {
        public IEnumerable<DishFamilyItemModel> List { get; set; }
        public DishFamilyFilterViewModel Filter { get; set; }

    }
}
