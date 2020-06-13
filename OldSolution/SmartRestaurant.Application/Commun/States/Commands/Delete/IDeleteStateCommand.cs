namespace SmartRestaurant.Application.Commun.State.Commands.Delete
{
    public interface IDeleteStateCommand
    {
        void Execute(DeleteStateModel model);
    }
}