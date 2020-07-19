using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.ViewModels.DeseasesAllergies;
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
            catch (Exception ee)
            {

            }
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (((Label)sender).BindingContext != null)
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!SectionsListViewModel.Seats.SelectedSeat.IlnessesAllergiesClicked)
            {
                await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new DeseasesAllergiesPage(new DeseasesAllergiesListViewModel(
    SectionsListViewModel.Seats.SelectedSeat
    )));

            }
            else
            {
                if (SectionsListViewModel.Seats.Seats.Any(s => s.CurrentOrder.Lines == null ||
    s.CurrentOrder.Lines.Count == 0))
                {

                    if (SectionsListViewModel.Seats.SelectedSeat.CurrentOrder.Lines != null && SectionsListViewModel.Seats.SelectedSeat.CurrentOrder.Lines.Count > 0)
                        await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new DinerCommandRecap());

                }
                else
                {
                    await App.Current.MainPage.Navigation.PushAsync(new GlobalRecap(
                        SectionsListViewModel.Seats.SelectedSeat.Table
                        ));
                }
            }
        }

        private object await(CustomNavigationPage mainPage)
        {
            throw new NotImplementedException();
        }
    }
}