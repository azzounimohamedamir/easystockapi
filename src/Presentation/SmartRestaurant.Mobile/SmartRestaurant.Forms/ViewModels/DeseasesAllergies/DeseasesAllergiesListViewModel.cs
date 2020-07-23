using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Services;
using SmartRestaurant.Diner.ViewModels.Sections;
using SmartRestaurant.Diner.ViewModels.Tables;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.DeseasesAllergies
{
    /// <summary>
    /// Used to bind the Deseases and allergies View.
    /// So this class contain the list of allergies and deseases to be selected by the customer.
    /// </summary>
    public class DeseasesAllergiesListViewModel : SimpleViewModel
    {
        /// <summary>
        /// Deseases is bind to a List control, and it's fill when an object is instantiated to be binded to the View.
        /// </summary>
        public IList<DeseasesViewModel> Deseases { get; set; }

        /// <summary>
        /// Allergies is bind to a List control, and it's fill when an object is instantiated to be binded to the View.
        /// </summary>
        public IList<AllergiesViewModel> Allergies { get; set; }
        private readonly SeatViewModel _seat;
        /// <summary>
        /// Constructor to fill allergies and deseases.
        /// </summary>
        public DeseasesAllergiesListViewModel(SeatViewModel seat)
        {
            _seat = seat;
            // Fill the deseases
            ObservableCollection<DeseaseModel> listDeseases = DeseasesService.GetListDeseases();
            Deseases = new ObservableCollection<DeseasesViewModel>();
            foreach (var item in listDeseases)
            {
                Deseases.Add(new DeseasesViewModel(item));
            }


            // Fill the allergies.
            ObservableCollection<AllergyModel> listAllergies = AllergiesService.GetListAllergies();
            Allergies = new ObservableCollection<AllergiesViewModel>();
            foreach (var item in listAllergies)
            {
                Allergies.Add(new AllergiesViewModel(item));
            }
        }

        #region Properties to select deseases or allergies.
        /// <summary>
        /// Every time the user click or tape on a desease the DeseaseViewModel associated is updated by update the property IsSelected 
        /// </summary>
        private DeseasesViewModel selectedDesease;
        public DeseasesViewModel SelectedDesease
        {
            get { return selectedDesease; }
            set
            {
                SetPropertyValue(ref selectedDesease, value);
                if (SelectedDesease != null)
                    SelectedDesease.IsSelected = !SelectedDesease.IsSelected;
            }
        }

        /// <summary>
        /// /// <summary>
        /// Every time the user click or tape on an allergy the AllergiesViewModel associated is updated by update the property IsSelected 
        /// </summary>
        /// </summary>
        private AllergiesViewModel selectedAllergy;
        public AllergiesViewModel SelectedAllergy
        {
            get { return selectedAllergy; }
            set
            {
                SetPropertyValue(ref selectedAllergy, value);
                if (SelectedAllergy != null)
                    SelectedAllergy.IsSelected = !SelectedAllergy.IsSelected;
            }
        }
        #endregion


        #region Property to set the orientation of Text from right to left or from left to right
        /// <summary>
        /// Used to set the Orientation of the controls on the view from right to left or from left to right accoring to the language selected by the customer
        /// </summary>
        public TextAlignment OrientationText
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? TextAlignment.End : TextAlignment.Start;
                }
                else
                {
                    return TextAlignment.Start;
                }
            }
        }
        #endregion


        #region Command property for navigation
        /// <summary>
        /// This command is used to navigate to the next page or view.
        /// </summary>
        public ICommand NextCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try

                    {
                        if (SectionsListViewModel.Seats.Seats.Any(s => s.CurrentOrder.Lines == null ||
s.CurrentOrder.Lines.Count == 0))
                        {
                            _seat.IlnessesAllergiesClicked =
                           SectionsListViewModel.Seats.SelectedSeat.IlnessesAllergiesClicked = true;

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
                    catch (Exception)
                    {

                    }
                });
            }
        }
        #endregion        
        public FlowDirection FlowDirectionValue
        {

            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
                }
                else
                {
                    return FlowDirection.LeftToRight;
                }
            }
        }
    }
}
