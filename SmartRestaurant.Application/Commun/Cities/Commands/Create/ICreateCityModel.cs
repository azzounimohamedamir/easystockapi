namespace SmartRestaurant.Application.Commun.Cities.Commands
{
    public interface ICreateCityModel
    {
        string Alias { get; set; }
        string IsoCode { get; set; }
        string Name { get; set; }
        string StateId { get; set; }
        
    }
}