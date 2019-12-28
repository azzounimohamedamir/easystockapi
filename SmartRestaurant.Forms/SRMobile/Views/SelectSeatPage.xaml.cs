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
    }
}