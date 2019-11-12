using MultiGestureViewPlugin;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.ViewModels.Tables;
using SmartRestaurant.Diner.ViewModels.Zones;
using SmartRestaurant.Diner.Views.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace SmartRestaurant.Diner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZonesAndTablesPage : ContentPage
    {

        public ZonesAndTablesPage(ZonesListViewModel _model)
        {
            InitializeComponent();


            BindingContext = _model;
            viewmodel = (ZonesListViewModel)BindingContext;
            


        }
        public ZonesListViewModel viewmodel { get; private set; }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            try
            {
                var vm = BindingContext as ZonesListViewModel;
                var zone = e.Item as ZonesViewModel;
                vm.HideOrShowItem(zone);
            }
            catch(Exception ee)
            {

            }
        }

        private async void FlowListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //foreach (TablesViewModel t in ((ZonesListViewModel)BindingContext).SelectedZone.Tables.Tables)
            //    t.IsSelected = false;
            //if(((ZonesListViewModel)BindingContext).SelectedTable !=null)
            //((ZonesListViewModel)BindingContext).SelectedTable.IsSelected = true;

            if (!((TablesViewModel)(((((View)sender))).BindingContext)).IsSelected)
            {
                foreach (TablesViewModel t in ((ZonesListViewModel)BindingContext).SelectedZone.Tables.Tables)
                    if (t.Numero != ((TablesViewModel)(((View)sender).BindingContext)).Numero)
                        t.IsSelected = false;
                //((TablesViewModel)(((Label)sender).BindingContext)).IsSelected=!((TablesViewModel)(((Label)sender).BindingContext)).IsSelected;
                if (!((TablesViewModel)(((((View)sender))).BindingContext)).IsSelected)
                    this.viewmodel.SelectedTable = ((TablesViewModel)(((View)sender).BindingContext));
                else
                    this.viewmodel.SelectedTable = null;
            }
            var scaleAnimation = new ScaleAnimation
            {
                PositionIn = MoveAnimationOptions.Right,
                PositionOut = MoveAnimationOptions.Left
            };

            cs_popup =
            new ChairSelectionPopup(
                (TablesViewModel)(((View)sender).BindingContext))
            {
                Animation = scaleAnimation
            };
            await PopupNavigation.PushAsync(cs_popup
            , true);
            bool anyselectedchair = true;
            if (!anyselectedchair)
            {
                //Deselect the last selected table also its chairs
                //Select this table also its selected chairs
            }


        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        { 


        }

        private void MultiGestureView_LongPressed(object sender, EventArgs e)
        {

        }

        private void MultiGestureView_Tapped(object sender, EventArgs e)
        {

        }
        public static ChairSelectionPopup cs_popup;
        private async void GesturesContentView_GestureRecognized(object sender, XLabs.Forms.Behaviors.GestureResult e)
        {
            switch (e.GestureType)
            {
                case GestureType.LongPress:

                    if (!((TablesViewModel)(((((View)sender))).BindingContext)).IsSelected)
                    {
                        foreach (TablesViewModel t in ((ZonesListViewModel)BindingContext).SelectedZone.Tables.Tables)
                            if (t.Numero != ((TablesViewModel)(((GesturesContentView)sender).BindingContext)).Numero)
                                t.IsSelected = false;
                        //((TablesViewModel)(((Label)sender).BindingContext)).IsSelected=!((TablesViewModel)(((Label)sender).BindingContext)).IsSelected;
                        if (!((TablesViewModel)(((((View)sender))).BindingContext)).IsSelected)
                            this.viewmodel.SelectedTable = ((TablesViewModel)(((GesturesContentView)sender).BindingContext));
                        else
                            this.viewmodel.SelectedTable = null;
                    }
                    var scaleAnimation = new ScaleAnimation
                    {
                        PositionIn = MoveAnimationOptions.Right,
                        PositionOut = MoveAnimationOptions.Left
                    };

                    cs_popup =
                    new ChairSelectionPopup(
                        (TablesViewModel)(((GesturesContentView)sender).BindingContext))
                    {
                        Animation = scaleAnimation
                    };
                    await PopupNavigation.PushAsync(cs_popup
                    , true) ;
                    bool anyselectedchair = true;
                    if(!anyselectedchair)
                    {
                        //Deselect the last selected table also its chairs
                        //Select this table also its selected chairs
                    }
                    break;
                case GestureType.SingleTap:
                    foreach (TablesViewModel t in ((ZonesListViewModel)BindingContext).SelectedZone.Tables.Tables)
                        if (t.Numero != ((TablesViewModel)(((GesturesContentView)sender).BindingContext)).Numero)
                            t.IsSelected = false;
                    //((TablesViewModel)(((Label)sender).BindingContext)).IsSelected=!((TablesViewModel)(((Label)sender).BindingContext)).IsSelected;
                    if (!((TablesViewModel)(((((View)sender))).BindingContext)).IsSelected)
                        this.viewmodel.SelectedTable = ((TablesViewModel)(((GesturesContentView)sender).BindingContext));
                    else
                        this.viewmodel.SelectedTable = null;
                    break;
                case GestureType.DoubleTap:
                    // Add code here
                    break;
                default:
                    break;
            }

        }
    }
}