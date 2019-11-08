namespace SmartRestaurant.Application.Restaurants.Places.Commands.Create
{
    public interface ICreatePlaceModel
    {
        string Alias { get; set; }
        string TableId { get; set; }
        string Description { get; set; }
        string Name { get; set; }
    }
}