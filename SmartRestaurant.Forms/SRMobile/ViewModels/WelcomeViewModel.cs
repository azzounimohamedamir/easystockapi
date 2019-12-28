using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.ViewModels.Sections;
using SmartRestaurant.Diner.ViewModels.Zones;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels
{
    /// <summary>
    /// The ViewModel of the welcome View
    /// </summary>
    public class WelcomeViewModel: SimpleViewModel
    {
        /// <summary>
        /// Command to navigate to the next page or view.
        /// </summary>
        public ICommand NextCommand
        {
            get
            {
                return new Command(async () => {
                    try

                    {
                        // await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new SectionsPage(new SectionsListViewModel()));
                        await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new SelectSeatPage(ZonesListViewModel.CurrentTable));
                    }
                    catch (Exception)
                    {

                    }
                });
            }
        }
    }
}
