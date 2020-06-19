using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Quantities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Commun
{
    public class QuantityViewModel
    {
        public QuantityViewModel(SelectUnitModel units)
        {            
            Units = units;
        }
        public SelectUnitModel Units { get; set; }        
        public QuantityModel Quantity { get; set; }
    }
}
