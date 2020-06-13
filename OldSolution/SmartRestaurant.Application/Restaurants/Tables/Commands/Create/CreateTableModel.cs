namespace SmartRestaurant.Application.Restaurants.Tables.Commands.Create
{
    public class CreateTableModel : ICreateTableModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string AreaId { get; set; }
        public bool IsDisabled { get; set; }
    }
}