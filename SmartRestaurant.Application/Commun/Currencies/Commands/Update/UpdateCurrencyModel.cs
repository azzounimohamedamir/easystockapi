using SmartRestaurant.Application.Commun.Currencies.Commands.Create;

namespace SmartRestaurant.Application.Commun.Currencies.Commands.Update
{
    public class UpdateCurrencyModel :CreateCurrencyModel,IUpdateCurrencyModel
    {



        public string Id { get; set; }
      
    }
}