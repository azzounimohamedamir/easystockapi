namespace SmartRestaurant.Application.Restaurants.Floors.Commands.Create
{
    public interface ICreateFloorModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string RestaurantId { get; set; }
    }
}