using SmartRestaurant.Application.Restaurants.Staffs.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Staffs.Commands.Update
{
    public interface IUpdateStaffModel: ICreateStaffModel
    {
        string Id { get; set; }
    }
}