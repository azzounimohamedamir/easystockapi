using Newtonsoft.Json;
using SmartRestaurant.Diner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace SmartRestaurant.Diner.Services
{
    /// <summary>
    /// this class is used to get deseases from the server API of local json file and stored them in a ListDeseases Object.
    /// </summary>
    public class DeseasesService
    {
        public static ObservableCollection<DeseaseModel> GetListDeseases()
        {
            var Deseases = JsonConvert.DeserializeObject<ListDeseasesObject>(SimpleService.GetJsonString("Repositories.ListDeseases.json")); ;
            
            if (Deseases.DeseasesList != null)
            {
                return new ObservableCollection<DeseaseModel>(Deseases.DeseasesList);
            }
            else
            {
                return new ObservableCollection<DeseaseModel>();
            }
        }
    }

    /// <summary>
    /// Used to store and manage deseases
    /// </summary>
    public class ListDeseasesObject
    {
        public IList<DeseaseModel> DeseasesList { get; set; }
    }
}
