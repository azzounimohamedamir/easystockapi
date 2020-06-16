using Newtonsoft.Json;
using SmartRestaurant.Diner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartRestaurant.Diner.Services
{
    /// <summary>
    /// this class is used to get tables from the server API of local json file and stored them in a ListTables Object.
    /// </summary>
    public class SpecificationService
    {
        static private ListSpecificationsObject Specifications;
        public static ObservableCollection<SpecificationModel> GetListSpecifications()
        {
            if(Specifications ==null)
            Specifications = JsonConvert.DeserializeObject<ListSpecificationsObject>(SimpleService.GetJsonString("Repositories.ListSpecifications.json"));            
            if (Specifications.SpecificationsList != null)
            {
                return new ObservableCollection<SpecificationModel>(Specifications.SpecificationsList);
            }
            else
            {
                return new ObservableCollection<SpecificationModel>();
            }
        }
    }

    /// <summary>
    /// Used to store and manage tables
    /// </summary>
    public class ListSpecificationsObject
    {
        public IList<SpecificationModel> SpecificationsList { get; set; }
    }
}
