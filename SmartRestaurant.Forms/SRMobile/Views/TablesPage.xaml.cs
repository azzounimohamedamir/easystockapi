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
    public partial class TablesPage : ContentPage
    {
        /// <summary>
        /// Constructor to bind an object of type TablesListViewModel to the context.
        /// </summary>
        /// <param name="_model"></param>
        public TablesPage(TablesListViewModel _model)
        {
            InitializeComponent();

            BindingContext = _model;
            Title = "Choix de la table";

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.LightBlue;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.MidnightBlue;
        }
    }
}