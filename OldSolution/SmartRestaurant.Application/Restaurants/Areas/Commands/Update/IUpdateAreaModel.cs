using SmartRestaurant.Application.Restaurants.Areas.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Areas.Commands.Update
{
    public interface IUpdateAreaModel: ICreateAreaModel
    {
        string Id { get; set; }
    }
}