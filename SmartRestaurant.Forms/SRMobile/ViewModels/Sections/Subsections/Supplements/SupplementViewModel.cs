using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections.Subsections.Supplementes.Supplements
{
    public class SupplementViewModel:SimpleViewModel
    {
        public readonly SupplementModel Supplement;
        
        /// <summary>
        /// Get the SupplementModel from the Model.
        /// </summary>
        /// <param name="_Supplement"></param>
        public SupplementViewModel(SupplementModel _Supplement)
        {
            this.Supplement = _Supplement;

        }

        public int Id
        {
            get
            {
                return Supplement.Id;
            }
        }


        #region Name of the Supplement according to the language selected.
        /// <summary>
        /// This property used to display Supplement name according to the CultureInfo (Language) used.
        /// if the CultureInfo used is arabic "ar" the Name take NameAr as name of the Supplement
        /// if the CultureInfo used is frensh "fr" the Name take NameFr as name of the Supplement
        /// if the CultureInfo used is english "en" the Name take NameEn as name of the Supplement
        /// </summary>
        public string Name
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? Supplement.NameAr : (AppResources.Culture.Name == "fr" ? Supplement.NameFr : Supplement.NameEn);
                }
                else
                {
                    return Supplement.NameEn;
                }
            }
        }

        /// <summary>
        /// Arabic name of the Supplement
        /// </summary>
        public string NameAr
        {
            get { return Supplement.NameAr; }
            set
            {
                if (Supplement.NameAr != value)
                {
                    Supplement.NameAr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// French name of the Supplement.
        /// </summary>
        public string NameFr
        {
            get { return Supplement.NameFr; }
            set
            {
                if (Supplement.NameFr != value)
                {
                    Supplement.NameFr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// English name of the Supplement.
        /// </summary>
        public string NameEn
        {
            get { return Supplement.NameEn; }
            set
            {
                if (Supplement.NameEn != value)
                {
                    Supplement.NameEn = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion


        #region Properties to manage images.
        /// <summary>
        /// Image to indicate the nature of the Supplement.
        /// </summary>
        public string Image
        {
            get { return Supplement.Image; }
        }

        public float Price
        {
            get { return Supplement.Price; }
            set
            {
                Supplement.Price = value;
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

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value != _isSelected)
                {
                    this._isSelected = value;
                    RaisePropertyChanged();
                }
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
        internal DishViewModel refDishViewModel { get; set; }
        public ICommand SelectEvent
        {
            get
            {
                return new Command(() =>
                {
                    IsSelected = !IsSelected;
                    if (IsSelected)
                        refDishViewModel.Price += Price;
                    else refDishViewModel.Price -= Price;
                });
            }
        }


    }
}
