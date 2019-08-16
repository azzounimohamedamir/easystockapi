using SmartRestaurant.Application.Commun.Countries.Commands.Create;

namespace SmartRestaurant.Application.Commun.State.Commands.Create
{
    public interface IUpdateStateModel : ICreateStateModel
    {
       string Id { get; set; }
    }
}