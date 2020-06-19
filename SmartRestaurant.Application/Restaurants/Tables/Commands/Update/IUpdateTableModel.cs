using SmartRestaurant.Application.Restaurants.Tables.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Tables.Commands.Update
{
    public interface IUpdateTableModel: ICreateTableModel
    {
        string Id { get; set; }
    }
}