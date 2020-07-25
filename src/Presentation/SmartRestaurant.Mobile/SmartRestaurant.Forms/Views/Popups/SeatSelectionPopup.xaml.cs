using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SmartRestaurant.Diner.ViewModels.Zones;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeatSelectionPopup : PopupPage
    {
        public ZonesListViewModel viewmodel { get; }
        private short oldvalue;
        public SeatSelectionPopup(ZonesListViewModel _model)
        {
            InitializeComponent();
            BindingContext = _model;
            oldvalue = _model.SelectedTable.SeatCount;
            minus_enabled = _model.SelectedTable.SeatCount > 0;
            plus_enabled = _model.SelectedTable.SeatCount < 99;
            viewmodel = _model;
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            ((ZonesListViewModel)BindingContext).SelectedTable.SeatCount
                = oldvalue;
            PopupNavigation.PopAllAsync(true);
            try
            {
                ((ZonesAndTablesPage)(((NavigationPage)Application.Current.MainPage)).CurrentPage).SetOpacity(1);
            }
            catch
            {

            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                if ((Convert.ToInt32(e.NewTextValue)) >= 0)
                {
                    ((ZonesListViewModel)BindingContext).SelectedTable.SeatCount

                        = ((ZonesListViewModel)BindingContext).SelectedTable.SeatCount;
                }
                if ((Convert.ToInt32(e.NewTextValue)) > 99)
                {

                    ((ZonesListViewModel)BindingContext).SelectedTable.SeatCount = 99;
                }
            }
            catch { ((ZonesListViewModel)BindingContext).SelectedTable.SeatCount = 0; }
        }
        bool minus_enabled;
        bool plus_enabled;
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (((ZonesListViewModel)BindingContext).SelectedTable.SeatCount < 99)
                ((ZonesListViewModel)BindingContext).SelectedTable.SeatCount++;
            else

                plus_enabled = false;
            minus_enabled = true;

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (((ZonesListViewModel)BindingContext).SelectedTable.SeatCount > 0)
                ((ZonesListViewModel)BindingContext).SelectedTable.SeatCount--;
            else

                minus_enabled = false;
            plus_enabled = true;

        }
    }
}