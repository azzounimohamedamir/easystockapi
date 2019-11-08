using SmartRestaurant.Forms.Interfaces;
using SmartRestaurant.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderStatusPage : ContentPage
    {

        public IAPIService api;
        public OrderStatusPage()
        {
            InitializeComponent();
         
        }
      }
}