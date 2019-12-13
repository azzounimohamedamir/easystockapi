using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.ViewModels.Sections.Subsections.Ingredientes.Ingredients;
using SmartRestaurant.Diner.ViewModels.Sections.Subsections.Specificationes.Specifications;
using SmartRestaurant.Diner.ViewModels.Sections.Subsections.Supplementes.Supplements;
using SmartRestaurant.Diner.ViewModels.Tables;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections
{
    /// <summary>
    /// Used to manage dishs as a ViewModel
    /// </summary>
    public class DishViewModel : SimpleViewModel
    {
        public readonly DishModel dish;
        public SubSectionViewModel SubSection { get; set; }

        /// <summary>
        /// Get the DishModel from the Model.
        /// </summary>
        /// <param name="_dish"></param>
        public DishViewModel(DishModel _dish)
        {
            Calories = _dish.Calories;
            Carbo = _dish.Carbo;
            Fat = _dish.Carbo;
            Protein = _dish.Protein;
            _EstimatedTime = _dish.EstimatedTime;
            Qty = 1;
            Total = Price = InitialPrice = _dish.Price;
            this.dish = _dish;
            Specifications = SectionsListViewModel.Specifications;
            Supplements = SectionsListViewModel.Supplements;
            foreach (var s in Specifications.Specifications)
            {
                for (int i = 0; i < s.RadioOptionsVM.Count; i++)
                {
                    s.RadioOptionsVM[i].IsSelected = i == 0;
                }

            }
            foreach (var s in Supplements.Supplements)
            {
                s.IsSelected = false;
                s.refDishViewModel = this;
            }

        }

        public int Id
        {
            get
            {
                return dish.Id;
            }
        }


        #region Name of the dish according to the language selected.
        /// <summary>
        /// This property used to display dish name according to the CultureInfo (Language) used.
        /// if the CultureInfo used is arabic "ar" the Name take NameAr as name of the dish
        /// if the CultureInfo used is frensh "fr" the Name take NameFr as name of the dish
        /// if the CultureInfo used is english "en" the Name take NameEn as name of the dish
        /// </summary>
        public string Name
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? dish.NameAr : (AppResources.Culture.Name == "fr" ? dish.NameFr : dish.NameEn);
                }
                else
                {
                    return dish.NameEn;
                }
            }
        }

        /// <summary>
        /// Arabic name of the dish
        /// </summary>
        public string NameAr
        {
            get { return dish.NameAr; }
            set
            {
                if (dish.NameAr != value)
                {
                    dish.NameAr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// French name of the dish.
        /// </summary>
        public string NameFr
        {
            get { return dish.NameFr; }
            set
            {
                if (dish.NameFr != value)
                {
                    dish.NameFr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// English name of the dish.
        /// </summary>
        public string NameEn
        {
            get { return dish.NameEn; }
            set
            {
                if (dish.NameEn != value)
                {
                    dish.NameEn = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion


        #region Properties to manage images.
        /// <summary>
        /// Image to indicate the nature of the dish.
        /// </summary>
        public ObservableCollection<string> Images
        {
            get { return new ObservableCollection<string>(dish.Images); }
        }
        private int _EstimatedTime;
        public int EstimatedTime
        {
            get { return _EstimatedTime; }
            set
            {
                _EstimatedTime = value;
                RaisePropertyChanged();
            }
        }
        private float _Price;
        public float Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                Total = Qty * _Price;
                RaisePropertyChanged();
            }
        }
        private float _InitialPrice;
        public float InitialPrice
        {
            get { return _InitialPrice; }
            set
            {
                _InitialPrice = value;
                RaisePropertyChanged();
            }
        }
        private int _Qty;
        public int Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;
                Total = _Qty * Price;
                RaisePropertyChanged();
            }
        }
        private float _Total;
        public float Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// The Uri of the image 
        /// </summary>
        public List<Uri> ImageUris
        {
            get
            {
                var uris = new List<Uri>();
                foreach (string i in Images)
                {
                    uris.Add(new Uri(i));
                }

                return uris;
            }
        }

        #endregion


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
        public int SubSectionId
        {
            get { return dish.SubSectionId; }
            set
            {
                if (dish.SubSectionId != value)
                {
                    dish.SubSectionId = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool isSelected = false;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    RaisePropertyChanged();

                }
            }
        }
        public ICommand ShowDishCommand
        {
            get
            {
                return new Command<SubSectionViewModel>(async (_subsection) => {
                    try
                    {
                        this.SubSection = _subsection;
                        await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new DishSelectPage(new DishViewModel(dish)));
                    }
                    catch (Exception)
                    {


                    }
                });
            }
        }
        private SupplementListViewModel _Supplements;
        public SupplementListViewModel Supplements
        {
            get
            {
                return _Supplements;
            }
            set
            {
                _Supplements = value;
                RaisePropertyChanged();
            }
        }
        public float Calories { get; set; }
        public float Carbo { get; set; }
        public float Fat { get; set; }
        public float Protein { get; set; }
        private SpecificationListViewModel _Specifications;
        public SpecificationListViewModel Specifications
        {
            get
            {

                return _Specifications;
            }
            set
            {
                _Specifications = value;
                RaisePropertyChanged();
            }
        }
        private List<IngredientViewModel> _Dish_Ingredients_Measures;
        public List<IngredientViewModel> Dish_Ingredients_Measures
        {
            get
            {
                #region Get Ingredients & their Measures  
                if (_Dish_Ingredients_Measures == null)
                {
                    _Dish_Ingredients_Measures = new List<IngredientViewModel>();

                    _Dish_Ingredients_Measures.Clear();
                    foreach (DishIngredient di in dish.Ingredients)
                    {
                        var ing = SectionsListViewModel.Ingredients.Ingredients.FirstOrDefault(i => i.Id == di.Id);
                        if (ing != null)
                        {
                            ing.Measure = di.Measure;
                            ing.IsPrincipal = true;
                            ing.refDishViewModel = this;
                            _Dish_Ingredients_Measures.Add(ing);
                        }
                    }
                    foreach (IngredientViewModel di in SectionsListViewModel.Ingredients.Ingredients)
                    {
                        if (dish.Ingredients.Select(d => d.Id).Contains(di.Id)) continue;
                        var ing = di;
                        ing.Measure = 0;
                        ing.IsPrincipal = false;
                        _Dish_Ingredients_Measures.Add(ing);
                    }
                }
                #endregion
                return _Dish_Ingredients_Measures;
            }

        }

        private bool _minus_enabled;
        public bool minus_enabled
        {
            get
            {
                _minus_enabled = Qty > 0;
                return _minus_enabled;
            }
            set
            {
                _minus_enabled = value;
                RaisePropertyChanged();
            }
        }
        private bool _plus_enabled;
        internal DishViewModel refDishViewModel { get; set; }

        public bool plus_enabled
        {
            get
            {
                _plus_enabled = Qty < 99;
                return _plus_enabled;
            }
            set
            {
                _plus_enabled = value;
                RaisePropertyChanged();
            }
        }

        public ICommand plus
        {
            get
            {
                return new Command(() => {
                    try
                    {
                        if (Qty < 99)
                        {
                            Qty++;

                        }
                        else

                            plus_enabled = false;
                        minus_enabled = true;
                    }
                    catch (Exception)
                    {


                    }
                });
            }
        }
        public ICommand minus
        {
            get
            {
                return new Command(() => {
                    try
                    {
                        if (Qty > 0)
                        {
                            Qty--;
                        }
                        else
                            minus_enabled = false;
                        plus_enabled = true;

                    }
                    catch (Exception)
                    {


                    }
                });
            }
        }
        public ICommand AddToOrder
        {
            get
            {
                return new Command(() =>
                {
                    SectionsListViewModel.Instance.SelectedDishes.Add(this);
                    SectionsListViewModel.Instance.SelectedDishes = SectionsListViewModel.Instance.SelectedDishes;
                    ((CustomNavigationPage)(App.Current.MainPage)).PopAsync();
                });
            }
        }
    }
}
