namespace SmartRestaurant.Application.Commun.Cities.Commands
{
    public class CreateCityModel : ICreateCityModel
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string StateId { get; set; }
        public string CountryId { get; set; }
        public string Alias { get; set; }
        public bool IsDisabled { get; set; }
    }
}