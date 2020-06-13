using SmartRestaurant.Application.Products.ProductFamilies.Commands.Create;

namespace SmartRestaurant.Application.Products.ProductFamilies.Commands.Update
{
    public interface IUpdateProductFamilyModel: ICreateProductFamilyModel
    {
        string Id { get; set; }
    }
}