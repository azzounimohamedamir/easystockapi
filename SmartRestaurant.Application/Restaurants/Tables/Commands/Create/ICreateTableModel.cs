namespace SmartRestaurant.Application.Restaurants.Tables.Commands.Create
{
    public interface ICreateTableModel
    {
        string Alias { get; set; }
        string AreaId { get; set; }
        string Description { get; set; }
        string Name { get; set; }
    }
}