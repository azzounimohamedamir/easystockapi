using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.ViewModels.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections
{
    /// <summary>
    /// Used to manage dishs as a ViewModel
    /// </summary>
    public class DishViewModel: SimpleViewModel
    {
        public readonly DishModel dish;

        /// <summary>
        /// Get the DishModel from the Model.
        /// </summary>
        /// <param name="_dish"></param>
        public DishViewModel(DishModel _dish)
        {
            this.dish = _dish;
        }

        public int Id { get; set; }
        

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
        public string Image
        {
            get { return dish.Image; }
            set
            {
                dish.Image = value;
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
                return String.IsNullOrEmpty(dish.Image) ? null : new Uri(Image);
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
        private bool isSelected;
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

    }
}
