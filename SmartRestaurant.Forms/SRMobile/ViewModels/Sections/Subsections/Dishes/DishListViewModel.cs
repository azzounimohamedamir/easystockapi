using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections
{
    /// <summary>
    /// Used to bind subsections liste with the View.
    /// </summary>
    public class DishListViewModel: SimpleViewModel
    {
        /// <summary>
        /// Dish to bind with the View.
        /// </summary>
        public ObservableCollection<DishViewModel> Dishes {
            get;
            set; }
        
        /// <summary>
        /// Constructor to Fill the List of subsections from the Database or Json file stored locally.
        /// </summary>
        public DishListViewModel(int _sectionid,int _subsectionid,SubSectionViewModel _section)
        {

            ObservableCollection<DishModel> listDish = SectionsService.GetListDishes(_sectionid,_subsectionid);
            Dishes = new ObservableCollection<DishViewModel>();
            foreach (var item in listDish)
            {
                Dishes.Add(new DishViewModel(item, _section));
            }
        }



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


        private SubSectionViewModel selectedDish;
        public SubSectionViewModel SelectedDish
        {
            get { return selectedDish; }
            set
            {
                SetPropertyValue(ref selectedDish, value);

            }
        }
        
    }
}
