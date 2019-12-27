using SmartRestaurant.Diner.ViewModels.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectSeatPage : ContentPage
    {
        public SelectSeatPage(TablesViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
        private async void FlowListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!((SeatViewModel)(e.Item)).IsSelected)
            {
                foreach (SeatViewModel t in ((TablesViewModel)BindingContext).Seats.Seats)
                    if (t.Id != ((SeatViewModel)(e.Item)).Id)
                        t.IsSelected = false;
                if (!((SeatViewModel)(e.Item)).IsSelected)
                    ((TablesViewModel)BindingContext).SelectedSeat = ((SeatViewModel)(e.Item));
                else
                    ((TablesViewModel)BindingContext).SelectedSeat = null;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (((TablesViewModel)BindingContext).SelectedSeat!=null)
                ((TablesViewModel)BindingContext).SelectedSeat.IsTaken = true;
        }
    }      
}