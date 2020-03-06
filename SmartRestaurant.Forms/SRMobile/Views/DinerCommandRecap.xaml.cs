using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.ViewModels.Orders;
using SmartRestaurant.Diner.ViewModels.Sections;
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
    public partial class DinerCommandRecap : ContentPage
    {
        public OrderViewModel viewmodel { get; private set; }
        public DinerCommandRecap()
        {
            InitializeComponent();            
            var sections =SectionsListViewModel.Seats.SelectedSeat.CurrentOrder.Lines.Select(d => d.SubSection.Section.Name);
            var sorted = from d in SectionsListViewModel.Seats.SelectedSeat.CurrentOrder.Lines
                         orderby d.SubSection.Section.Name
                         group d by d.SubSection.Section.Name into DishGroup
                             select new Grouping<string, DishViewModel>(DishGroup.Key, DishGroup);

            //create a new collection of groups
            SectionsListViewModel.Seats.SelectedSeat.CurrentOrder.DishesGrouped = new ObservableCollection<Grouping<string, DishViewModel>>(sorted);
            BindingContext = SectionsListViewModel.Seats.SelectedSeat.CurrentOrder;
            viewmodel = (OrderViewModel)BindingContext;
        }

        private  async void Button_Clicked(object sender, EventArgs e)
        {
            await((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new SectionsPage(SectionsListViewModel.Instance));
        }
    }
    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
    
}