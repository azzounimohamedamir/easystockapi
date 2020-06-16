using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Services;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Diner.ViewModels.Sections.Subsections.Supplementes.Supplements
{
    public class SupplementListViewModel : SimpleViewModel
    {
        private static List<SupplementViewModel> supplements;
        /// <summary>
        /// Supplement to bind with the View.
        /// </summary>
        public List<SupplementViewModel> Supplements
        {
            get
            {
                if (supplements == null)
                {
                    List<SupplementModel> listSupplement = SupplementService.GetListSupplements().ToList();
                    supplements = new List<SupplementViewModel>();
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
