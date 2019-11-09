using Newtonsoft.Json;
using SmartRestaurant.Diner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace SmartRestaurant.Diner.Services
{
    /// <summary>
    /// this class is used to get sections from the server API of local json file and stored them in a ListSections Object.
    /// </summary>
    public class SectionsService
    {
        public static ObservableCollection<SectionModel> GetListSections()
        {
            var Sections = JsonConvert.DeserializeObject<ListSectionsObject>(SimpleService.GetJsonString("Repositories.ListSections.json"));
            if (Sections.SectionsList != null)
            {
                return new ObservableCollection<SectionModel>(Sections.SectionsList);
            }
            else
            {
                return new ObservableCollection<SectionModel>();
            }
        }
    }

    /// <summary>
    /// Used to store and manage sections
    /// </summary>

    public class ListSectionsObject
    {
        public IList<SectionModel> SectionsList { get; set; }
    }
}
