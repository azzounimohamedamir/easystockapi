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


        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ((DeseasesViewModel)(((((View)sender))).BindingContext)).IsSelected =
                !((DeseasesViewModel)(((((View)sender))).BindingContext)).IsSelected;
        }
        private void TapGestureRecognizer_Tapped2(object sender, EventArgs e)
        {
            ((AllergiesViewModel)(((((View)sender))).BindingContext)).IsSelected =
                !((AllergiesViewModel)(((((View)sender))).BindingContext)).IsSelected;
        }
    }
}