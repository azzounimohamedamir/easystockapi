using SmartRestaurant.Diner.ViewModels;
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
    public partial class LanguageView : ContentPage
    {
        /// <summary>
        /// Constructor to bind an object of type LanguageViewModel to the context.
        /// </summary>
        /// <param name="_model"></param>
        public LanguageView(LanguageViewModel _model)
        {
            InitializeComponent();
            BindingContext = _model;
        }
    }
}