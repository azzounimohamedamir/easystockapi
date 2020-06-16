using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.ViewModels.Tables;
using SmartRestaurant.Diner.ViewModels.Zones;
using SmartRestaurant.Diner.Views.Popups;
using System;

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
            if (!((TablesViewModel)(e.Item)).IsSelected)
            {
                foreach (TablesViewModel t in ((ZonesListViewModel)BindingContext).SelectedZone.Tables.Tables)
                    if (t.Numero !=((TablesViewModel)( e.Item)).Numero)
                        t.IsSelected = false;
                if (!((TablesViewModel)(e.Item)).IsSelected)
                    this.viewmodel.SelectedTable = ((TablesViewModel)(e.Item));
                else
                    this.viewmodel.SelectedTable = null;
            }
            if (this.viewmodel.SelectedTable.SeatCount == 0)
            {
                var scaleAnimation = new ScaleAnimation
                {

                    PositionIn = MoveAnimationOptions.Center,
                    PositionOut = MoveAnimationOptions.Center,
                    ScaleIn = 3.2,
                    ScaleOut = 0.1,
                    DurationIn = 1500,
                    DurationOut = 1500,
                    HasBackgroundAnimation = true,
                    EasingIn = Easing.SinOut,
                    EasingOut = Easing.SinIn,
                };
                BackgroundColor = Color.FromHex("#777777");
                mainscv.Opacity = 0.53;

                cs_popup =
                new SeatSelectionPopup((ZonesListViewModel)BindingContext)
                {
                    Animation = scaleAnimation
                };
                await PopupNavigation.PushAsync(cs_popup
                , true);
            }
            else
            {
                await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new SelectSeatPage(((ZonesListViewModel)BindingContext).SelectedTable.Seats));
            }
        }


        public static SeatSelectionPopup cs_popup;
        private async void GesturesContentView_GestureRecognized(object sender, XLabs.Forms.Behaviors.GestureResult e)
        {
            if (e.GestureType == GestureType.SingleTap)
            {
                if (!((TablesViewModel)(((((View)sender))).BindingContext)).IsSelected)
                {
                    foreach (TablesViewModel t in ((ZonesListViewModel)BindingContext).SelectedZone.Tables.Tables)
                        if (t.Numero != ((TablesViewModel)(((GesturesContentView)sender).BindingContext)).Numero)
                            t.IsSelected = false;                   
                    if (!((TablesViewModel)(((((View)sender))).BindingContext)).IsSelected)
                        this.viewmodel.SelectedTable = ((TablesViewModel)(((GesturesContentView)sender).BindingContext));
                    else
                        this.viewmodel.SelectedTable = null;
                }
                if (this.viewmodel.SelectedTable.SeatCount == 0)
                {
                    var scaleAnimation = new ScaleAnimation
                    {

                        PositionIn = MoveAnimationOptions.Center,
                        PositionOut = MoveAnimationOptions.Center,
                        ScaleIn = 3.2,
                        ScaleOut = 0.1,
                        DurationIn = 1500,
                        DurationOut = 1500,
                        HasBackgroundAnimation = true,
                        EasingIn = Easing.SinOut,
                        EasingOut = Easing.SinIn,
                    };
                    BackgroundColor = Color.FromHex("#777777");
                    mainscv.Opacity = 0.53;

                    cs_popup =
                    new SeatSelectionPopup((ZonesListViewModel)BindingContext)
                    {
                        Animation = scaleAnimation
                    };
                    await PopupNavigation.PushAsync(cs_popup
                    , true);
                }
                else
                {
                    await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new SelectSeatPage(((ZonesListViewModel)BindingContext).SelectedTable.Seats));
                }

            }
            else
            if (e.GestureType == GestureType.LongPress)
            {
                try
                {

                    await App.Current.MainPage.Navigation.PushAsync(new GlobalRecap((TablesViewModel)(((((View)sender))).BindingContext)));
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        internal void SetOpacity(double v)
        {

            BackgroundColor = Color.White;
            mainscv.Opacity = v;
        }
    }
}