using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Utils
{
    public class SelectListViewModel
    {        
        public string EmptyOptionText { get; set; }  
        public string ActionUrl { get; set; }
        public string TargetId { get; set; }
        public SelectList Items { get; set; }
        public SelectListViewModel NestedItems { get; set; }
        public string AppendInput { get; set; }
    }
}
