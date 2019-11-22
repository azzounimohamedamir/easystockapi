using Newtonsoft.Json;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.ViewModels.Sections;
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
    /// this class is used to get sections from the server API of local json file and stored them in a ListSections Object.
    /// </summary>
    public class SectionsService
    {
        private static ListSectionsObject Sections;
        public static ObservableCollection<SectionModel> GetListSections()
        {
            InitData();
            if (Sections.SectionsList != null)
            {
                return new ObservableCollection<SectionModel>(Sections.SectionsList);
            }
            else
            {
                return new ObservableCollection<SectionModel>();
            }
        }
        private static void InitData()
        {
           if(Sections==null) Sections = JsonConvert.DeserializeObject<ListSectionsObject>(SimpleService.GetJsonString("Repositories.ListSections.json"));
        }
        internal static ObservableCollection<DishModel> GetListDishes(int sectionid, int subsectionid)
        {
            InitData();
            if (Sections.SectionsList != null)
            {
                return new ObservableCollection<DishModel>(
                    Sections.SectionsList.
                    FirstOrDefault(s=>s.Id==sectionid).
                    SubSections.FirstOrDefault
                    (b=>b.Id==subsectionid).Dishes.ToList()
                    );
            }
            else
            {
                return new ObservableCollection<DishModel>();
            }
            
        }

        internal static ObservableCollection<SubSectionModel> GetListSubSections(int sectionid)
        {
            InitData();
            if (Sections.SectionsList != null)
            {
                return new ObservableCollection<SubSectionModel>(
                    Sections.SectionsList.
                    FirstOrDefault(s => s.Id == sectionid).
                    SubSections.ToList()
                    );
            }
            else
            {
                return new ObservableCollection<SubSectionModel>();
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
