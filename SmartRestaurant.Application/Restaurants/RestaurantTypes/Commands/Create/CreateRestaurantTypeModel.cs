namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create
{
    public class CreateRestaurantTypeModel : ICreateRestaurantTypeModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
    }
}