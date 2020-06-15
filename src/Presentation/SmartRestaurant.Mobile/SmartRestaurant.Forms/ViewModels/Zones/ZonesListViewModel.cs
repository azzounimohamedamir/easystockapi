using Rg.Plugins.Popup.Services;
using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Services;
using SmartRestaurant.Diner.ViewModels.Tables;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Zones
{
    /// <summary>
    /// Used to bind zones liste with the View.
    /// </summary>
    public class ZonesListViewModel: SimpleViewModel
    {
        /// <summary>
        /// Zones to bind with the View.
        /// </summary>
        public ObservableCollection<ZonesViewModel> Zones { get; set; }
        
        /// <summary>
        /// Constructor to Fill the List of zones from the Database or Json file stored locally.
        /// </summary>
        public ZonesListViewModel()
        {

            ObservableCollection<ZoneModel> listZones = ZoneService.GetListZones();
            Zones = new ObservableCollection<ZonesViewModel>();
            foreach (var item in listZones)
            {
                Zones.Add(new ZonesViewModel(item));
            }
        }

        private ZonesViewModel OldZone;
        public void HideOrShowItem(ZonesViewModel zone)
        {
            if (OldZone == zone)
            {
                zone.IsVisible = !zone.IsVisible;
                UpdateZone(zone);
            }
            else
            {
                if (OldZone != null)
                {
                    OldZone.IsVisible = false;
                    UpdateZone(OldZone);
                }
                zone.IsVisible = true;
                UpdateZone(zone);
            }
            OldZone = zone;
        }

        public void UpdateZone(ZonesViewModel zone)
        {
            var index = Zones.IndexOf(zone);
            Zones.Remove(zone);
            Zones.Insert(index, zone);
        }
        /// <summary>
        /// The TableViewModel selected by the user to serve  the customer
        /// </summary>
        private TablesViewModel selectedTable;
        public TablesViewModel SelectedTable
        {
            get { return selectedTable; }
            set
            {
                if (selectedTable != value)
                {
                    if (SelectedTable != null)
                        SelectedTable.IsSelected = !SelectedTable.IsSelected;
                    SetPropertyValue(ref selectedTable, value);
                    if (SelectedTable != null)
                        SelectedTable.IsSelected = !SelectedTable.IsSelected;
                }
            }
        }


        private ZonesViewModel selectedZone;
        public ZonesViewModel SelectedZone
        {
            get { return selectedZone; }
            set
            {
                SetPropertyValue(ref selectedZone, value);

            }
        }
        /// <summary>
        /// Command to navigate to the next page or view.
        /// </summary>
        public ICommand NextCommand
        {
            get
            {
                return new Command(async() => {
                    try
                    {
                        await PopupNavigation.PopAllAsync(true);
                        ((ZonesAndTablesPage)(((NavigationPage )Application.Current.MainPage)).CurrentPage).SetOpacity (1);

                        //Post new state 

                        selectedTable.SeatCount = ZonesAndTablesPage.cs_popup.viewmodel.selectedTable.SeatCount;
                        if (selectedTable.SeatCount > 0)
                        {
                            await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new SelectSeatPage(SelectedTable.Seats));
                        }
                    }
                    catch (Exception)
                    {

                         
                    }
                });
            }
        }
    }
}
