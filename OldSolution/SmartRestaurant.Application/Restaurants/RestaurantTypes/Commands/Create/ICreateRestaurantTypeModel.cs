namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create
{
    public interface ICreateRestaurantTypeModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Name { get; set; }
    }
}