using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Create;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Update;

namespace SmartRestaurant.Client.Web.Models.Restaurants
{
    public class StaffViewModel
    {
        public StaffViewModel()
        {

        }
        public SelectList Parents { get; set; }
        public SelectList Roles { get; set; }

        public UpdateStaffModel UpdateModel { get; set; }
        public CreateStaffModel CreateModel { get; set; }
    }
}
