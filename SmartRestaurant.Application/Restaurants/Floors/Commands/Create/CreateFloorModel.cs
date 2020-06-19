namespace SmartRestaurant.Application.Restaurants.Floors.Commands.Create
{
    public class CreateFloorModel : ICreateFloorModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        
        public string Description { get; set; }
        public string RestaurantId { get; set; }
        public bool IsDisabled { get; set; }

    }
}