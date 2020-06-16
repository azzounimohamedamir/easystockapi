using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Views;
using System;
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
                         await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new DeseasesAllergiesPage(new DeseasesAllergies.DeseasesAllergiesListViewModel()));                        
                    }
                    catch (Exception)
                    {

                    }
                });
            }
        }
    }
}
