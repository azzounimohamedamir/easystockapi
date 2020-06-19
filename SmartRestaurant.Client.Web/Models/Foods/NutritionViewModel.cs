using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Foods.Models;
using SmartRestaurant.Client.Web.Models.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
