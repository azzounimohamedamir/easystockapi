using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Services;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;
namespace SmartRestaurant.Diner.ViewModels.Orders
{
    public class OrderListViewModel : SimpleViewModel
    {
        private static ObservableCollection<OrderViewModel> orders;
        /// <summary>
        /// Order to bind with the View.
        /// </summary>
        public ObservableCollection<OrderViewModel> Orders
        {
            get
            {
                if (orders == null) orders = new ObservableCollection<OrderViewModel>();
                return orders;
            }
            set
            {
                orders = value;
                RaisePropertyChanged();
            }

        }
        public ObservableCollection<Grouping<int, OrderViewModel>> GroupedOrders
        {
            get
            {
                var sorted = from d in Orders
                             orderby d.SeatNumber
                             group d by d.SeatNumber into OrderGroup
                             select new Grouping<int, OrderViewModel>(OrderGroup.Key, OrderGroup);

                return new ObservableCollection<Grouping<int, OrderViewModel>>(sorted);
            }
        }

    }
}
