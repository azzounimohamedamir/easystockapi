using SmartRestaurant.Application.Restaurants.Staffs.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Staffs.Commands.Update
{
    public class UpdateStaffModel : CreateStaffModel, IUpdateStaffModel
    {
        public string Id { get; set; }
        public bool IsDisabled { get;  set; }
    }
}