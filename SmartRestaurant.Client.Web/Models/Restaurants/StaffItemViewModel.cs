using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Staffs.Queries;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class StaffItemViewModel
    {
        public StaffItemViewModel()
        {

        }
        public SelectList Parents { get; set; }
        public SelectList Roles { get; set; }
        public string SelectedParentId { get; set; }
        public string SelectedRole { get; set; }
        public IEnumerable<StaffItemModel> Entities { get; set; }
    }
}
