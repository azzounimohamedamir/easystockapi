using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Foods
{
    public class FoodListFilterViewModel
    {
       
        public SelectList Categories { get; set; }
        public string FoodCategoryId { get; set; }
        public string Name { get; set; }  
    }
}
