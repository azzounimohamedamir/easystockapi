using MultiGestureViewPlugin;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
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
    public partial class SubSectionsDishesPage : ContentPage
    {

        public SubSectionsDishesPage(SubSectionsListViewModel _model)
        {
            InitializeComponent();

            
            BindingContext = _model;
            viewmodel = (SubSectionsListViewModel)BindingContext;
            


        }
        public SubSectionsListViewModel viewmodel { get; private set; }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            try
            {
                var vm = BindingContext as SubSectionsListViewModel;
                var subsection = e.Item as SubSectionViewModel;
                vm.HideOrShowItem(subsection);
            }
            catch(Exception ee)
            {

            }
        }

        private async void FlowListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!((DishViewModel)(e.Item)).IsSelected)
            {
                foreach (DishViewModel t in ((SubSectionsListViewModel)BindingContext).SelectedSubSection.Dishes.Dishes)
                    if (t.Id !=((TablesViewModel)( e.Item)).Id)
                        t.IsSelected = false;
                if (!((DishViewModel)(e.Item)).IsSelected)
                    this.viewmodel.SelectedDish = ((DishViewModel)(e.Item));
                else
                    this.viewmodel.SelectedDish = null;
            }            
      
        }

        private async void GesturesContentView_GestureRecognized(object sender, XLabs.Forms.Behaviors.GestureResult e)
        {
            if (e.GestureType == GestureType.SingleTap)
            {
                if (!((DishViewModel)(((((View)sender))).BindingContext)).IsSelected)
                {
                    foreach (DishViewModel t in ((SubSectionsListViewModel)BindingContext).SelectedSubSection.Dishes.Dishes)
                        if (t.Id != ((DishViewModel)(((GesturesContentView)sender).BindingContext)).Id)
                            t.IsSelected = false;                   
                    if (!((DishViewModel)(((((View)sender))).BindingContext)).IsSelected)
                        this.viewmodel.SelectedDish = ((DishViewModel)(((GesturesContentView)sender).BindingContext));
                    else
                        this.viewmodel.SelectedDish = null;
                }
  


            }
        }
    }
}