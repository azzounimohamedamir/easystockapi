using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.ViewModels.Sections;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Tables
{
    /// <summary>
    /// Used to bind tables liste with the View.
    /// </summary>
    public class SeatsListViewModel : SimpleViewModel
    {
        /// <summary>
        /// Tables to bind with the View.
        /// </summary>
        public IList<SeatViewModel> Seats { get; set; }
        public string Numero_Table { get; set; }
        /// <summary>
        /// Constructor to Fill the List of tables from the Database or Json file stored locally.
        /// </summary>
        public SeatsListViewModel(TablesViewModel table)
        {
            Numero_Table = table.Numero;
            Seats = new List<SeatViewModel>();
            table.CurrentOrders = null;
            for (int i = 1; i <= table.SeatCount; i++)
            {
                Seats.Add(new SeatViewModel(table.Id, i, table.Numero, table));
            }
        }



        /// <summary>
        /// The TableViewModel selected by the user to serve  the customer
        /// </summary>
        private SeatViewModel selectedSeat;
        public SeatViewModel SelectedSeat
        {
            get { return selectedSeat; }
            set
            {
                SetPropertyValue(ref selectedSeat, value);
                if (SelectedSeat != null)
                    SelectedSeat.IsSelected = !SelectedSeat.IsSelected;
            }
        }
        public ICommand NextCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (SelectedSeat != null)
                        {
                            SelectedSeat.IsTaken = true;
                            SectionsListViewModel.Seats = this;
                            if (SelectedSeat.CurrentOrder.Lines != null && SelectedSeat.CurrentOrder.Lines.Count > 0)
                                await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new DinerCommandRecap());
                            else
                                await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new LanguageView(new LanguageViewModel()));
                        }
                    }
                    catch (Exception)
                    {


                    }
                });
            }
        }
        public ICommand ViewDinerCommandRecap
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (SelectedSeat != null)
                        {
                            SelectedSeat.IsTaken = true;
                            await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new DinerCommandRecap());
                        }
                    }
                    catch (Exception)
                    {


                    }
                });
            }
        }
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
        public TextAlignment OrientationTextInverted
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? TextAlignment.Start : TextAlignment.End;
                }
                else
                {
                    return TextAlignment.End;
                }
            }
        }

        private SeatViewModel OldSeat;
        public void HideOrShowItem(SeatViewModel seat)
        {
            if (OldSeat == seat)
            {
                seat.IsVisible = !seat.IsVisible;
                UpdateSeat(seat);
            }
            else
            {
                if (OldSeat != null)
                {
                    OldSeat.IsVisible = false;
                    UpdateSeat(OldSeat);
                }
                seat.IsVisible = true;
                UpdateSeat(seat);
            }
            OldSeat = seat;
        }

        public void UpdateSeat(SeatViewModel seat)
        {
            var index = Seats.IndexOf(seat);
            Seats.Remove(seat);
            Seats.Insert(index, seat);
        }

        private double _ConvertedTotalDollar;
        public double ConvertedTotalDollar
        {
            get
            {
                return (Math.Round(Total / (SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 2).
                    ExchangeRate == 0 ? 1 : SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 2).ExchangeRate), 2));
            }
            set
            {
                _ConvertedTotalDollar = value;
                RaisePropertyChanged();
            }
        }
        private double _ConvertedTotalEuro;
        public double ConvertedTotalEuro
        {
            get
            {
                return (Math.Round(Total / (SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 1).
                    ExchangeRate == 0 ? 1 : SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 1).ExchangeRate), 2));
            }
            set
            {
                _ConvertedTotalDollar = value;
                RaisePropertyChanged();
            }
        }
        private string _Euro;
        public string Euro
        {
            get
            {
                return SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 1).
                    Name;
            }
            set
            {
                _Euro = value;
                RaisePropertyChanged();
            }
        }
        private string _Dollar;
        public string Dollar
        {
            get
            {
                return SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 2).
                    Name;
            }
            set
            {
                _Dollar = value;
                RaisePropertyChanged();
            }
        }
        private double total;
        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                ConvertedTotalEuro =
(Math.Round(Total / (SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 1).
ExchangeRate == 0 ? 1 : SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 1).ExchangeRate), 2));
                ConvertedTotalDollar =
(Math.Round(Total / (SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 2).
    ExchangeRate == 0 ? 1 : SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 2).ExchangeRate), 2));

                RaisePropertyChanged();
            }
        }

    }
}
