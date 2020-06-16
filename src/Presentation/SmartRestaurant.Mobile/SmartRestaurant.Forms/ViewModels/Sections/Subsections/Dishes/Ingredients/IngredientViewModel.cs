using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections.Subsections.Ingredientes.Ingredients
{
    public class IngredientViewModel:SimpleViewModel
    {
        public readonly IngredientModel Ingredient;
        
        /// <summary>
        /// Get the IngredientModel from the Model.
        /// </summary>
        /// <param name="_Ingredient"></param>
        public IngredientViewModel(IngredientModel _Ingredient)
        {
            this.Ingredient = _Ingredient;
            calories= _Ingredient.Calories;
            carbo = _Ingredient.Carbo;
            fat = _Ingredient.Fat;
            protein = _Ingredient.Protein;

        }

        public int Id
        {
            get
            {
                return Ingredient.Id;
            }
        }


        #region Name of the Ingredient according to the language selected.
        /// <summary>
        /// This property used to display Ingredient name according to the CultureInfo (Language) used.
        /// if the CultureInfo used is arabic "ar" the Name take NameAr as name of the Ingredient
        /// if the CultureInfo used is french "fr" the Name take NameFr as name of the Ingredient
        /// if the CultureInfo used is english "en" the Name take NameEn as name of the Ingredient
        /// </summary>
        public string Name
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? Ingredient.NameAr : (AppResources.Culture.Name == "fr" ? Ingredient.NameFr : Ingredient.NameEn);
                }
                else
                {
                    return Ingredient.NameEn;
                }
            }
        }

        /// <summary>
        /// Arabic name of the Ingredient
        /// </summary>
        public string NameAr
        {
            get { return Ingredient.NameAr; }
            set
            {
                if (Ingredient.NameAr != value)
                {
                    Ingredient.NameAr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// French name of the Ingredient.
        /// </summary>
        public string NameFr
        {
            get { return Ingredient.NameFr; }
            set
            {
                if (Ingredient.NameFr != value)
                {
                    Ingredient.NameFr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// English name of the Ingredient.
        /// </summary>
        public string NameEn
        {
            get { return Ingredient.NameEn; }
            set
            {
                if (Ingredient.NameEn != value)
                {
                    Ingredient.NameEn = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion


        #region Properties to manage images.
        /// <summary>
        /// Image to indicate the nature of the Ingredient.
        /// </summary>
        public string Image
        {
            get { return Ingredient.Image; }
        }
        public int Weight
        {
            get { return Ingredient.Weight; }
            set
            {
                Ingredient.Weight = value;
                RaisePropertyChanged();
            }
        }
        public float Price
        {
            get { return Ingredient.Price; }
            set
            {
                Ingredient.Price = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The Uri of the image 
        /// </summary>
        public Uri ImageUri
        {
            get
            {
                return new Uri(Image);

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
        private int measure;
        public int Measure
        {
            get
            {
                return measure;
            }
            set
            {
                measure = value;
                minus_enabled = (measure > 0 && !IsPrincipal) || measure > 1;
                plus_enabled = measure < 99;
                RaisePropertyChanged();

            }
        }

        private bool _minus_enabled;
        public bool minus_enabled
        {
            get
            {
                _minus_enabled = (measure > 0 && !IsPrincipal) || measure > 1;
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
                _plus_enabled= Measure < 99;
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
                        if (Measure < 99)
                        {
                            Measure++;
                            refDishViewModel.Price += Price;
                            refDishViewModel.Calories += Calories;
                            refDishViewModel.Fat += Fat;
                            refDishViewModel.Protein += Protein;
                            refDishViewModel.Carbo += Carbo;
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
                        if ((Measure > 0 && !IsPrincipal) || Measure > 1)
                        {
                            Measure--;
                            refDishViewModel.Price -= Price;
                            refDishViewModel.Calories -= Calories;
                            refDishViewModel.Fat -= Fat;
                            refDishViewModel.Protein -= Protein;
                            refDishViewModel.Carbo -= Carbo;
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
        public bool IsPrincipal { get; set; }
        private float calories;
        private float carbo;
        private float fat;
        private float protein;
        public float Calories { get => calories; set => calories = value; }
        public float Carbo { get => carbo; set => carbo = value; }
        public float Fat { get => fat; set => fat = value; }
        public float Protein { get => protein; set => protein = value; }

    }
}
