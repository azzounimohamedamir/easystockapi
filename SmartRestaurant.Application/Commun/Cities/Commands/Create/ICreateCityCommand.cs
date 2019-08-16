namespace SmartRestaurant.Application.Commun.Cities.Commands
{
    public interface ICreateCityCommand
    {
        void Execute(CreateCityModel model);
    }
}