namespace SmartRestaurant.Application.Commun.Currencies.Commands.Create
{
    public class CreateCurrencyModel : ICreateCurrencyModel
    {


        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Alias { get; set; }
        public bool IsDisabled { get; set; }        
        public string Symbol { get; set; }
    }
}