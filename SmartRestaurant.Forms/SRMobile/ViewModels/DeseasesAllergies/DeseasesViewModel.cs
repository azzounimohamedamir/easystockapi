using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Diner.ViewModels.DeseasesAllergies
{
    /// <summary>
    ///  Used to manage deseases object as a ViewModel
    /// </summary>
    public class DeseasesViewModel : SimpleViewModel
    {
        readonly DeseaseModel desease;
        public DeseasesViewModel(DeseaseModel _desease)
        {
            this.desease = _desease;
        }

        public int Id { get; set; }

        #region name of the Desease according to the selected language.
        /// <summary>
        /// This property used to display desease name according to the CultureInfo (Language) used.
        /// if the CultureInfo used is arabic "ar" the Name take NameAr as name of the desease
        /// if the CultureInfo used is frensh "fr" the Name take NameFr as name of the desease
        /// if the CultureInfo used is english "en" the Name take NameEn as name of the desease
        /// </summary>
        public string Name
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? desease.NameAr : (AppResources.Culture.Name == "fr" ? desease.NameFr : desease.NameEn);
                }
                else
                {
                    return desease.NameEn;
                }
            }
        }

        /// <summary>
        /// Arabic name of the desease.
        /// </summary>
        public string NameAr
        {
            get { return desease.NameAr; }
            set
            {
                if (desease.NameAr != value)
                {
                    desease.NameAr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Frensh name of the desease.
        /// </summary>
        public string NameFr
        {
            get { return desease.NameFr; }
            set
            {
                if (desease.NameFr != value)
                {
                    desease.NameFr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// English name of the desease.
        /// </summary>
        public string NameEn
        {
            get { return desease.NameEn; }
            set
            {
                if (desease.NameEn != value)
                {
                    desease.NameEn = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion


        #region Property to identify the selected desease.
        /// <summary>
        ///  Used to indicate the desease selected by the customer.
        /// </summary>
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
        #endregion


        #region Properties to set the visibility of the right or left ChackBox
        /// <summary>
        /// If it's true then the right checkbox is visible
        /// </summary>
        public bool RightCheck
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? true : false;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// if it's true then the left checkbox is visible
        /// </summary>
        public bool LeftCheck
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? false : true;
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion
    }
}
