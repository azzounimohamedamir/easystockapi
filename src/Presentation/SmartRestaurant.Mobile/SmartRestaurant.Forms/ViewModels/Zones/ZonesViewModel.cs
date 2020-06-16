using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.ViewModels.Tables;
using System.Linq;

namespace SmartRestaurant.Diner.ViewModels.Zones
{
    /// <summary>
    /// Used to manage zones as a ViewModel
    /// </summary>
    public class ZonesViewModel: SimpleViewModel
    {
        readonly ZoneModel zone;

        /// <summary>
        /// Get the ZoneModel from the Model.
        /// </summary>
        /// <param name="_zone"></param>
        public ZonesViewModel(ZoneModel _zone)
        {
            this.zone = _zone;
        }

        public int Id { get; set; }
        
        public string Name
        {
            get { return zone.Name; }
            set
            {
                if (zone.Name != value)
                {
                    zone.Name = value;
                    RaisePropertyChanged();
                }
            }
        }
        public TablesListViewModel Tables {

            get { return new TablesListViewModel(zone.Id); }
            set
            {
                if (zone.Tables != value)
                {                    
                    zone.Tables = value.Tables.Select(t => t.table).ToList();
                    RaisePropertyChanged();
                }
            }
        }
        public bool IsVisible { get; set; }

    }
}
