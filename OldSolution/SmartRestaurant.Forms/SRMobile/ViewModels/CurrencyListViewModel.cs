using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections.Subsections.Currencies.Currencies
{
    public class CurrencyListViewModel : SimpleViewModel
    {
        private static ObservableCollection<CurrencyViewModel> currencies;
        /// <summary>
        /// Currency to bind with the View.
        /// </summary>
        public ObservableCollection<CurrencyViewModel> Currencies
        {
            get
            {
                if (currencies == null)
                {
                    ObservableCollection<CurrencyModel> listCurrency = CurrencyService.GetListCurrencies();
                    currencies = new ObservableCollection<CurrencyViewModel>();
                    foreach (var item in listCurrency)
                    {
                        currencies.Add(new CurrencyViewModel(item));
                    }
                }
                return currencies;
            }
            set
            {
                currencies = value;
                RaisePropertyChanged();
            }

        }

    }
}
