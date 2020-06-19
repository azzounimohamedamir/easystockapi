namespace SmartRestaurant.Application.Commun.Cities.Commands.Update
{
    public class UpdateCityModel : CreateCityModel, IUpdateCityModel
    {

        public string Id { get; set; }

    }
}