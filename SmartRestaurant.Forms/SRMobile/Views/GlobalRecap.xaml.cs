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
            int i = 0;
            foreach (SeatViewModel s in tablevm.Seats.Seats)
            {
                if(s.CurrentOrder==null || s.CurrentOrder.Lines==null || s.CurrentOrder.Lines.Count==0)
                {
                    i++;
                    continue;
                }
                var sorted2 = from d in s.CurrentOrder.Lines
                             orderby d.SubSection.Section.Name
                             group d by d.SubSection.Section.Name into DishGroup
                             select new Grouping<string, DishViewModel>(DishGroup.Key, DishGroup);
                tablevm.Seats.Seats[i].CurrentOrder.DishesGrouped = new ObservableCollection<Grouping<string, DishViewModel>>(sorted2);
                i++;
            }
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