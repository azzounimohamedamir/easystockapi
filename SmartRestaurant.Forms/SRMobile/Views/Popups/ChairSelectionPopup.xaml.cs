using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SmartRestaurant.Diner.ViewModels.Tables;
using SmartRestaurant.Diner.ViewModels.Zones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace SmartRestaurant.Diner.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChairSelectionPopup : PopupPage
    {
        public ZonesListViewModel viewmodel { get; }
        private short oldvalue;
        public ChairSelectionPopup(ZonesListViewModel _model)
        {
            InitializeComponent();

            BindingContext = _model;
            oldvalue = _model.SelectedTable.NombreChaises;
            viewmodel = _model;


            Title = "Nombre de chaises";


        }

    
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            ((ZonesListViewModel)BindingContext).SelectedTable.NombreChaises = oldvalue;
            PopupNavigation.PopAllAsync(true);
            ((ZonesAndTablesPage)(((NavigationPage)Application.Current.MainPage)).CurrentPage).SetOpacity(1);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            try
            {
                if ((Convert.ToInt32(e.NewTextValue))>=0)
                {
                    ((ZonesListViewModel)BindingContext).SelectedTable.NombreChaises = ((ZonesListViewModel)BindingContext).SelectedTable.NombreChaises;
                }
                    }
            catch { ((ZonesListViewModel)BindingContext).SelectedTable.NombreChaises = 0; }
        }
    }
}