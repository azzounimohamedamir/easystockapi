namespace SmartRestaurant.Application.Products.ProductFamilies.Commands.Create
{
    public class CreateProductFamilyModel : ICreateProductFamilyModel
    {
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }

        public bool IsDisabled { get; set; }
    }
}