using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Services;
using SmartRestaurant.Diner.ViewModels.Orders;
using SmartRestaurant.Diner.ViewModels.Sections.Subsections.Currencies.Currencies;
using SmartRestaurant.Diner.ViewModels.Sections.Subsections.Ingredientes.Ingredients;
using SmartRestaurant.Diner.ViewModels.Sections.Subsections.Specificationes.Specifications;
using SmartRestaurant.Diner.ViewModels.Sections.Subsections.Supplementes.Supplements;
using SmartRestaurant.Diner.ViewModels.Tables;
using SmartRestaurant.Diner.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections
{

    /// <summary>
    /// Used to bind Sections List to the view.
    /// </summary>
    public class SectionsListViewModel: SimpleViewModel
    {
        public static SupplementListViewModel Supplements { get; set; }
        public static IngredientListViewModel Ingredients { get; set; }
        public static CurrencyListViewModel Currencies { get; set; }
        public static SpecificationListViewModel Specifications { get; set; }
        public static SectionsListViewModel Instance { get; set; }
        public static SeatsListViewModel Seats { get; set; }
        private static OrderListViewModel orders;
        public static OrderListViewModel Orders {
            get
            {
                if (orders == null) orders = new OrderListViewModel();
                return orders;
            }

            set
            {
                orders = value;
            }
        } 
        /// <summary>
        /// The list of section to be binded to the List control.
        /// </summary>
        public IList<SectionViewModel> Sections { get; set; }


        /// <summary>
        /// Constructor to fill the list of section from the service class
        /// </summary>
        public SectionsListViewModel()
        {
            Supplements = new SupplementListViewModel() ;
            Ingredients = new IngredientListViewModel() ;
            Currencies = new CurrencyListViewModel() { Currencies = null } ;
            Specifications = new SpecificationListViewModel() ;
            ObservableCollection<SectionModel> listSections = SectionsService.GetListSections();
            Sections = new ObservableCollection<SectionViewModel>();
            foreach (var item in listSections)
            {
                Sections.Add(new SectionViewModel(item));
            }
            Instance = this;
        }
        /// <summary>
        /// Used to manage text orientation from right to left or from left to right accorging the langage selected.
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
         private List<DishViewModel> selectedDishes; 

        public List<DishViewModel> SelectedDishes
        {
            get
            {
                if (selectedDishes == null)
                    selectedDishes = new List<DishViewModel>();
                
                return selectedDishes;
            }
            set
            {
                selectedDishes = value;
                TotalPrice= SelectedDishes.Sum(d => d.Price * d.Qty);
                Seats.SelectedSeat.CurrentOrder.Lines = SelectedDishes;
                Seats.SelectedSeat.CurrentOrder.Calories = SelectedDishes.Sum(d => d.Calories*d.Qty);
                Seats.SelectedSeat.CurrentOrder.Fat = SelectedDishes.Sum(d => d.Fat * d.Qty);
                Seats.SelectedSeat.CurrentOrder.Protein = SelectedDishes.Sum(d => d.Protein * d.Qty);
                Seats.SelectedSeat.CurrentOrder.Carbo = SelectedDishes.Sum(d => d.Carbo * d.Qty);
                Seats.SelectedSeat.CurrentOrder.Total = TotalPrice;
                var sections = SectionsListViewModel.Seats.SelectedSeat.CurrentOrder.Lines.Select(d => d.SubSection.Section.Name);
                var sorted = from d in SectionsListViewModel.Seats.SelectedSeat.CurrentOrder.Lines
                             orderby d.SubSection.Section.Name
                             group d by d.SubSection.Section.Name into DishGroup
                             select new Grouping<string, DishViewModel>(DishGroup.Key, DishGroup);

                //create a new collection of groups
                SectionsListViewModel.Seats.SelectedSeat.CurrentOrder.DishesGrouped = new ObservableCollection<Grouping<string, DishViewModel>>(sorted);
                Seats.Seats[Seats.Seats.IndexOf(Seats.Seats.FirstOrDefault(s => s.SeatNumber == Seats.SelectedSeat.SeatNumber))] = Seats.SelectedSeat;
                Seats.Total = Seats.Seats.Sum(s => s.CurrentOrder.Total);
                RaisePropertyChanged();

            }
        }

         public double TotalPrice
        {
            get { return SelectedDishes.Sum(d => d.Price * d.Qty); }
            set {
                if(TotalPrice!=value)
                    TotalPrice = value;
                    RaisePropertyChanged();
                
            }

        }

    }
}
