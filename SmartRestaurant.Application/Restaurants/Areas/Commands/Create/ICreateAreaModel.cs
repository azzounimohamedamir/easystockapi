namespace SmartRestaurant.Application.Restaurants.Areas.Commands.Create
{
    public interface ICreateAreaModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string FloorId { get; set; }
        string Name { get; set; }
    }
}