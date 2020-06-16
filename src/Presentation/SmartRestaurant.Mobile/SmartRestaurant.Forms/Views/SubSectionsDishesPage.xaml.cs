using SmartRestaurant.Diner.ViewModels.Sections;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
             

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if(((Label)sender).BindingContext !=null)
                {
                (((Label)sender).BindingContext as DishViewModel).IsSelected = !(((Label)sender).BindingContext as DishViewModel).IsSelected;
                if (SectionsListViewModel.Instance.SelectedDishes.Select(d => d.Id).Contains((((Label)sender).BindingContext as DishViewModel).Id))
                {
                    SectionsListViewModel.Instance.SelectedDishes.Remove(
                        (((Label)sender).BindingContext as DishViewModel));
                }
                else
                {

                    SectionsListViewModel.Instance.SelectedDishes.Add(
                        (((Label)sender).BindingContext as DishViewModel));
                }
                SectionsListViewModel.Instance.SelectedDishes = SectionsListViewModel.Instance.SelectedDishes;
            }
        }
        
    }
}