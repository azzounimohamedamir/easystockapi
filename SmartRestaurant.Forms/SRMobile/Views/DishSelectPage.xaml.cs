using MultiGestureViewPlugin;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.ViewModels.Sections;
using SmartRestaurant.Diner.ViewModels.Tables;
using SmartRestaurant.Diner.ViewModels.Zones;
using SmartRestaurant.Diner.Views.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace SmartRestaurant.Diner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DishSelectPage : ContentPage
    {

        public DishSelectPage(DishViewModel _model)
        {
            InitializeComponent();
            BindingContext = _model;
            viewmodel = (DishViewModel)BindingContext;
            
        }
        public DishViewModel viewmodel { get; private set; }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as RadioOption;

            if (item == null)
                return;

            foreach (var group in ((DishViewModel)BindingContext).Specifications.Specifications)
            {
                if (group.RadioOptionsVM.Contains(item))
                {
                    foreach (var s in group.RadioOptionsVM.Where(x => x.IsSelected))
                    {
                        s.IsSelected = false;
                    }

                    item.IsSelected = true;
                }
            }
        }
    }
}