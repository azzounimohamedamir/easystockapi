namespace SmartRestaurant.Application.Products.ProductFamilies.Commands.Create
{
    public interface ICreateProductFamilyModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string RestaurantId { get; set; }
         
    }
}