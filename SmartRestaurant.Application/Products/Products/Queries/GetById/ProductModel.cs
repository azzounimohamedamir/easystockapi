namespace SmartRestaurant.Application.Products.Products.Queries.GetAll
{
    public class ProductItemModel
    {
        public string Id { get; set; }
        public string SlugUrl { get; set; }
        public string Name { get; set; }
        public string ProductFamilyName { get; set; }
        public string IsDisabled { get; set; }

        public string RestaurantName { get; set; }
        public string Alias { get; set; }
        public string PictureUrl { get; set; }
    }
}