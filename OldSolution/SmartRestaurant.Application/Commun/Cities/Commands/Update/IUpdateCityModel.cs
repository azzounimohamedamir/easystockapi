namespace SmartRestaurant.Application.Commun.Cities.Commands.Update
{
    public interface IUpdateCityModel : ICreateCityModel
    {
         string Id { get; set; }
    }
}