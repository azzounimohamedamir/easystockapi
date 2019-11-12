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
        private int oldvalue;
        public ChairSelectionPopup(ZonesListViewModel _model)
        {
            InitializeComponent();

            BindingContext = _model;
            oldvalue = _model.SelectedTable.TakenChairs;
            viewmodel = _model;


            Title = "Nombre de chaises";


        }

        private async void GesturesContentView_GestureRecognized(object sender, XLabs.Forms.Behaviors.GestureResult e)
        {
            //switch (e.GestureType)
            //{
                
            //    case GestureType.SingleTap:
            //        foreach (ChairsViewModel t in ((ChairsListViewModel)BindingContext).Chairs)
            //            if (t.Numero != ((ChairsViewModel)(((GesturesContentView)sender).BindingContext)).Numero)
            //                t.IsSelected = false;
            //        if (!((ChairsViewModel)(((((View)sender))).BindingContext)).IsSelected)
            //            this.viewmodel.SelectedChair = ((ChairsViewModel)(((GesturesContentView)sender).BindingContext));
            //        else
            //        {
            //            this.viewmodel.SelectedChair = null;
            //            ((ChairsListViewModel)BindingContext).SelectedChair.IsSelected = false;
            //        }
            //        break;
               
            //    default:
            //        break;
            //}

        }
        private void FlowListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //foreach (ChairsViewModel t in ((ChairsListViewModel)BindingContext).Chairs)
            //    t.IsSelected = false;
            //if (((ChairsListViewModel)BindingContext).SelectedChair != null)
            //    ((ChairsListViewModel)BindingContext).SelectedChair.IsSelected = true;
            


        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            ((ZonesListViewModel)BindingContext).SelectedTable.TakenChairs = oldvalue;
            PopupNavigation.PopAllAsync(true);
        }
    
    }
}