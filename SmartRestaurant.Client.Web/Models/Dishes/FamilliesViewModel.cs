using SmartRestaurant.Application.Dishes.DishFamillies.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class FamilliesViewModel
    {
        public IEnumerable<DishFamilyItemModel> List { get; set; }
        public DishFamilyFilterViewModel Filter { get; set; }

    }
}
