using SmartRestaurant.Diner.ViewModels.DeseasesAllergies;
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
    public partial class DeseasesAllergiesPage : ContentPage
    {

        /// <summary>
        /// Constructor to bind an object of type DeseasesAllergiesListViewModel to the context.
        /// </summary>
        /// <param name="_model"></param>
        public DeseasesAllergiesPage(DeseasesAllergiesListViewModel _model)
        {
            InitializeComponent();

            BindingContext = _model;

            Title = "Maladies et allergies";

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.LightBlue;
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.MidnightBlue;
        }
    }
}