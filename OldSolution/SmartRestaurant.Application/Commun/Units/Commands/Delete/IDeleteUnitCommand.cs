namespace SmartRestaurant.Application.Commun.Units.Commands.Delete
{
    public interface IDeleteUnitCommand
    {
        void Execute(DeleteUnitModel model);
    }
}