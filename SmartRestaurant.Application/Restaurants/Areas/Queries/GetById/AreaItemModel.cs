namespace SmartRestaurant.Application.Restaurants.Areas.Queries.GetById
{
    public class AreaItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string IsDisabled { get; set; }
 
        public string FloorName { get; set; }
    }
}