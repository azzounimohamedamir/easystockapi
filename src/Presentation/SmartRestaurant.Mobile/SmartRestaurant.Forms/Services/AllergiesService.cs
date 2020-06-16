using Newtonsoft.Json;
using SmartRestaurant.Diner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartRestaurant.Diner.Services
{
    /// <summary>
    /// this class is used to get allergies from the server API of local json file and stored them in a ListAllergies object.
    /// </summary>
    public class AllergiesService
    {
        public static ObservableCollection<AllergyModel> GetListAllergies()
        {
            var lao = JsonConvert.DeserializeObject<ListAllergiesObject>(SimpleService.GetJsonString("Repositories.ListAllergies.json"));            
            if (lao.ListAllergies != null)
            {
                return new ObservableCollection<AllergyModel>(lao.ListAllergies);
            }
            else
            {
                return new ObservableCollection<AllergyModel>();
            }
        }
    }

    /// <summary>
    /// Use to store and manage the allergies
    /// </summary>
    public class ListAllergiesObject
    {
        public IList<AllergyModel> ListAllergies { get; set; }
    }
}
