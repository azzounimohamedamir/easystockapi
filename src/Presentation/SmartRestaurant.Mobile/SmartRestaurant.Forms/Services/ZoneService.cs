using Newtonsoft.Json;
using SmartRestaurant.Diner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartRestaurant.Diner.Services
{
    /// <summary>
    /// this class is used to get zones from the server API of local json file and stored them in a ListZones Object.
    /// </summary>
    public class ZoneService
    {
        public static ObservableCollection<ZoneModel> GetListZones()
        {
            
            var Zones = JsonConvert.DeserializeObject < ListZones > (SimpleService.GetJsonString("Repositories.ListZones.json"));
            foreach (ZoneModel z in Zones.ZonesList)
            {
                z.Tables = TableService.GetListTables(z.Id);
            }
            if (Zones.ZonesList != null)
            {
                return new ObservableCollection<ZoneModel>(Zones.ZonesList);
            }
            else
            {
                return new ObservableCollection<ZoneModel>();
            }
        }
    }

    /// <summary>
    /// Used to store and manage zones
    /// </summary>
    public class ListZones
    {
        public IList<ZoneModel> ZonesList { get; set; }
    }
}
