using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections.Subsections.Specificationes.Specifications
{
    public  class SpecificationListViewModel:SimpleViewModel
    {
        private static ObservableCollection<SpecificationViewModel> specifications;
        public SpecificationListViewModel()
        {
            if (specifications == null)
            {
                ObservableCollection<SpecificationModel> listSpecification = SpecificationService.GetListSpecifications();
                specifications = new ObservableCollection<SpecificationViewModel>();
                foreach (var item in listSpecification)
                {
                    specifications.Add(new SpecificationViewModel(item));
                }
            }
        }

        /// <summary>
        /// Specification to bind with the View.
        /// </summary>
        public  ObservableCollection<SpecificationViewModel> Specifications
        {
            get
            {
                if (specifications == null)
                {
                    ObservableCollection<SpecificationModel> listSpecification = SpecificationService.GetListSpecifications();
                    specifications = new ObservableCollection<SpecificationViewModel>();
                    foreach (var item in listSpecification)
                    {
                        specifications.Add(new SpecificationViewModel(item));
                    }                    
                }
                return specifications;
            }


        }

  }
}
