using Newtonsoft.Json;
using SmartRestaurant.Diner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartRestaurant.Diner.Services
{
    /// <summary>
    /// this class is used to get tables from the server API of local json file and stored them in a ListTables Object.
    /// </summary>
    public class CurrencyService
    {
        static private ListCurrenciesObject Currencies;
        public static ObservableCollection<CurrencyModel> GetListCurrencies()
        {
            if(Currencies ==null)
            Currencies = JsonConvert.DeserializeObject<ListCurrenciesObject>(SimpleService.GetJsonString("Repositories.ListCurrencies.json"));            
            if (Currencies.CurrenciesList != null)
            {
                return new ObservableCollection<CurrencyModel>(Currencies.CurrenciesList);
            }
            else
            {
                return new ObservableCollection<CurrencyModel>();
            }
        }
    }

    /// <summary>
    /// Used to store and manage tables
    /// </summary>
    public class ListCurrenciesObject
    {
        public IList<CurrencyModel> CurrenciesList { get; set; }
    }
}
