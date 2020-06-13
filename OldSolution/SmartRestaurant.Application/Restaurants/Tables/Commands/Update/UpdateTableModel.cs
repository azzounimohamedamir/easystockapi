using SmartRestaurant.Application.Restaurants.Tables.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Tables.Commands.Update
{
    public class UpdateTableModel : CreateTableModel, IUpdateTableModel
    {
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        public string FloorId { get; set; }
        public string AreaName { get;  set; }
    }
}