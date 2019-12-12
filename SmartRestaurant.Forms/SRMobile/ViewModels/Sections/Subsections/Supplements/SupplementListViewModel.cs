using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections.Subsections.Supplementes.Supplements
{
    public class SupplementListViewModel : SimpleViewModel
    {
        private static ObservableCollection<SupplementViewModel> supplements;
        /// <summary>
        /// Supplement to bind with the View.
        /// </summary>
        public ObservableCollection<SupplementViewModel> Supplements
        {
            get
            {
                if (supplements == null)
                {
                    ObservableCollection<SupplementModel> listSupplement = SupplementService.GetListSupplements();
                    supplements = new ObservableCollection<SupplementViewModel>();
                    foreach (var item in listSupplement)
                    {
                        supplements.Add(new SupplementViewModel(item));
                    }
                }
                return supplements;
            }
            set
            {
                supplements = value;
                RaisePropertyChanged();
            }

        }

    }
}
