using SmartRestaurant.Application.Commun.Units.Commands.Create;

namespace SmartRestaurant.Application.Commun.Units.Commands.Update
{
    public interface IUpdateUnitModel : ICreateUnitModel
    {
        string Id { get; set; }
    }
}