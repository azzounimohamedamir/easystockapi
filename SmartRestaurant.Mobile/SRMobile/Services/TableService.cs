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
    public class TableService
    {
        public static ObservableCollection<TableModel> GetListTables()
        {
            var Tables = JsonConvert.DeserializeObject<ListTablesObject>(SimpleService.GetJsonString("Repositories.ListTables.json"));
            //string jsonFileName = "Repositories.ListTables.json";
            //ListTables Tables = new ListTables();
            //var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            //using (var reader = new System.IO.StreamReader(stream))
            //{
            //    var jsonString = reader.ReadToEnd();
            //
            //    Tables = JsonConvert.DeserializeObject<ListTables>(jsonString);
            //}
            if (Tables.TablesList != null)
            {
                return new ObservableCollection<TableModel>(Tables.TablesList);
            }
            else
            {
                return new ObservableCollection<TableModel>();
            }
        }
        public static ObservableCollection<TableModel> GetListTables(int idzone)
        {
            var Tables = JsonConvert.DeserializeObject<ListTablesObject>(SimpleService.GetJsonString("Repositories.ListTables.json"));

            if (Tables.TablesList != null)
            {
                return new ObservableCollection<TableModel>(Tables.TablesList.Where(t => t.ZoneId == idzone));
            }
            else
            {
                return new ObservableCollection<TableModel>();
            }
        }
    }

    /// <summary>
    /// Used to store and manage tables
    /// </summary>
    public class ListTablesObject
    {
        public IList<TableModel> TablesList { get; set; }
    }
}
