namespace SmartRestaurant.Application.Commun.Currencies.Commands.Create
{
    public interface ICreateCurrencyModel
    {
        string Alias { get; set; }
        string IsoCode { get; set; }
        string Name { get; set; }
        string Symbol { get; set; }
    }
}