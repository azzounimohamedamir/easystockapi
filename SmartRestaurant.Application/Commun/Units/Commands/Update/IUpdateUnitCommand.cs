namespace SmartRestaurant.Application.Commun.Units.Commands.Update
{
    public interface IUpdateUnitCommand
    {
        void Execute(UpdateUnitModel model);
    }
}