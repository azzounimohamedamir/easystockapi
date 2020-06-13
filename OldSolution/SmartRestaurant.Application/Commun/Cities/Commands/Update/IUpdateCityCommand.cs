namespace SmartRestaurant.Application.Commun.Cities.Commands.Update
{
    public interface IUpdateCityCommand
    {
        void Execute(UpdateCityModel model);
    }
}