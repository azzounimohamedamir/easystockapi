using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

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

    }
}
