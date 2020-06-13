namespace SmartRestaurant.Application.Commun.Units.Commands.Create
{
    public interface ICreateUnitCommand
    {
        void Execute(CreateUnitModel model);
    }
}