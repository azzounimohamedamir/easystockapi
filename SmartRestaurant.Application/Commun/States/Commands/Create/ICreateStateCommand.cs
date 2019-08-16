using SmartRestaurant.Application.Commun.Countries.Commands.Create;

namespace SmartRestaurant.Application.Commun.State.Commands.Create
{
    public interface ICreateStateCommand
    {
        void Execute(CreateStateModel model);
    }
}