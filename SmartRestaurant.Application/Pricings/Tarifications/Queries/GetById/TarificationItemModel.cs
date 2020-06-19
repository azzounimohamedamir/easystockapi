namespace SmartRestaurant.Application.Pricings.Tarifications.Queries.GetById
{
    public class TarificationItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string RestaurantName { get; set; }
        public string SlugUrl { get; set; }
        public string IsDisabled { get; set; }
        public bool IsPercentage { get; set; }
        public decimal Amount { get; set; }
    }
}