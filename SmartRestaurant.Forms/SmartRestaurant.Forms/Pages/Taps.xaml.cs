using SmartRestaurant.Forms.Models;
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
    public partial class Taps : TabbedPage
    {
        public OrdersViewModel OrdersViewModel;
        public Taps()
        {
            InitializeComponent();
           //this.BindingContext =  new OrdersViewModel();
        }

        private void SelectedDish(object sender, SelectedItemChangedEventArgs e)
        {
            ///TODO:I Will try to Pass Dish Type With Ingrediants
            ///to add  hover color over listitemviews 
            
            //Navigation.PushAsync(new DishDetails());
        }
    }
   
}