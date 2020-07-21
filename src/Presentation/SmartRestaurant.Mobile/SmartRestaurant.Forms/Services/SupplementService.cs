using Newtonsoft.Json;
using SmartRestaurant.Diner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SmartRestaurant.Diner.Services
{
    /// <summary>
    /// this class is used to get tables from the server API of local json file and stored them in a ListTables Object.
    /// </summary>
    public class SupplementService
    {
        static private ListSupplementsObject Supplements;
        public static ObservableCollection<SupplementModel> GetListSupplements()
        {
            if(Supplements ==null)
            Supplements = JsonConvert.DeserializeObject<ListSupplementsObject>(SimpleService.GetJsonString("Repositories.ListSupplements.json"));            
            if (Supplements.SupplementsList != null)
            {
                return new ObservableCollection<SupplementModel>(Supplements.SupplementsList);
            }
            else
            {
                return new ObservableCollection<SupplementModel>();
            }
        }
    }

    /// <summary>
    /// Used to store and manage tables
    /// </summary>
    public class ListSupplementsObject
    {
        public IList<SupplementModel> SupplementsList { get; set; }
    }
}
