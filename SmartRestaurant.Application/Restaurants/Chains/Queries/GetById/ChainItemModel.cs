namespace SmartRestaurant.Application.Restaurants.Chains.Queries.GetById
{
    public class ChainItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string IsDisabled { get; set; }

        public string OwnerName { get; set; }
        public string OwnerId { get; set; }
    }
}