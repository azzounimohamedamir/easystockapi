using SmartRestaurant.Application.Foods.Commands.Create;

namespace SmartRestaurant.Application.Foods.Commands.Update
{
    public interface IUpdateFoodModel : IFoodModelCommand
    {
        string Id { get; set; }
    }
}