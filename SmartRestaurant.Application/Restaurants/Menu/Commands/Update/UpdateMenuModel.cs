namespace SmartRestaurant.Application.Restaurants.Menu.Commands.Update
{
    public class UpdateMenuModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
        public string MenuId { get; set; }
        public string RestaurantId { get; set; }
    }
}