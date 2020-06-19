using SmartRestaurant.Application.Products.Products.Commands.Create;

namespace SmartRestaurant.Application.Products.Products.Commands.Update
{
    public interface IUpdateProductModel : ICreateProductModel
    {
        string Id { get; set; }
    }
}