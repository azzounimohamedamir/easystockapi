using SmartRestaurant.Diner.ViewModels.Tables;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectSeatPage : ContentPage
    {
        public SelectSeatPage(SeatsListViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
        private async void FlowListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!((SeatViewModel)(e.Item)).IsSelected)
            {
                foreach (SeatViewModel t in ((SeatsListViewModel)BindingContext).Seats)
                    if (t.Id != ((SeatViewModel)(e.Item)).Id)
                        t.IsSelected = false;
                if (!((SeatViewModel)(e.Item)).IsSelected)
                    ((SeatsListViewModel)BindingContext).SelectedSeat = ((SeatViewModel)(e.Item));
                else
                    ((SeatsListViewModel)BindingContext).SelectedSeat = null;
            }
            if (((SeatsListViewModel)BindingContext).NextCommand.CanExecute(null))
                ((SeatsListViewModel)BindingContext).NextCommand.Execute(null);
        }
    }      
}