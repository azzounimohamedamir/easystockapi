namespace SmartRestaurant.Application.Products.ProductFamilies.Queries.GetByRestaurantId
{
    public class ProductFamilyItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string SlugUrl { get; set; }
        public string RestaurantName { get; set; }
        public string IsDisabled { get; set; }

    }
}