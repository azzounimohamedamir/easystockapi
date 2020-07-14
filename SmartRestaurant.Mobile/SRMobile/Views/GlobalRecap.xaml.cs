using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.ViewModels.Orders;
using SmartRestaurant.Diner.ViewModels.Sections;
using SmartRestaurant.Diner.ViewModels.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GlobalRecap : ContentPage
    {
        public TablesViewModel viewmodel { get; private set; }
        public GlobalRecap(TablesViewModel tablevm)
        {
            InitializeComponent();
            BindingContext = tablevm;
            viewmodel = (TablesViewModel)BindingContext;
        }


        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            try
            {
                var vm = (BindingContext as TablesViewModel).Seats;
                var seat = e.Item as SeatViewModel;
                vm.HideOrShowItem(seat);
            }
            catch (Exception ee)
            {

            }
        }

    }
   
    
}