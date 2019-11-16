using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using IntelliAbb.Xamarin.Controls;
using SmartRestaurant.Diner.ViewModels.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SectionsPage : ContentPage
    {
        SectionsListViewModel model;

        /// <summary>
        /// Constructor to bind an object of type SectionsListViewModel to the context.
        /// </summary>
        /// <param name="_model"></param>
        public SectionsPage(SectionsListViewModel _model)
        {
            InitializeComponent();
            model = _model;
            BindingContext = model;
        }
    }
}