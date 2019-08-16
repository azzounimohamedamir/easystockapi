namespace SmartRestaurant.Application.Restaurants.Places.Commands.Create
{
    public class CreatePlaceModel : ICreatePlaceModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string TableId { get; set; }
        public bool IsDisabled { get; set; }
    }
}