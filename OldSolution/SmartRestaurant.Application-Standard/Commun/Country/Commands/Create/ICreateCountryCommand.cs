namespace SmartRestaurant.Application.Commun.Country.Commands.Create
{
    public interface ICreateCountryCommand
    {
        void Execute(CreateCountryModel model);
    }
}