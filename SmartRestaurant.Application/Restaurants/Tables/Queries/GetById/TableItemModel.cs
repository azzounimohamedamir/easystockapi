namespace SmartRestaurant.Application.Restaurants.Tables.Queries.GetById
{
    public class TableItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string AreaName { get; set; }
        public string FloorName { get; set; }

        public string IsDisabled { get; set; }
    }
}