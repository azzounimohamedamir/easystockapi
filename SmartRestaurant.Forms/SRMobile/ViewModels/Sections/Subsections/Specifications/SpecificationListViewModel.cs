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
        private static List<SpecificationViewModel> specifications;
        public SpecificationListViewModel()
        {
            if (specifications == null)
                specifications = new List<SpecificationViewModel>();
            ObservableCollection<SpecificationModel> listSpecification = SpecificationService.GetListSpecifications();
            specifications.Clear();
                foreach (var item in listSpecification)
                {
                    specifications.Add(new SpecificationViewModel(item));
                }
            
        }

        /// <summary>
        /// Specification to bind with the View.
        /// </summary>
        public List<SpecificationViewModel> Specifications
        {
            get
            {                
                return specifications;
            }


        }

  }
}
