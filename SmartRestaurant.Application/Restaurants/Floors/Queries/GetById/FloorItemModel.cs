namespace SmartRestaurant.Application.Restaurants.Floors.Queries.GetById
{
    public class FloorItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string IsDisabled { get; set; }

        public string RestaurantName { get; set; }
    }
}