using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;

namespace SmartRestaurant.Diner.ViewModels.DeseasesAllergies
{
    /// <summary>
    /// Used to manage allergies objects as a ViewModel
    /// </summary>
    public class AllergiesViewModel : SimpleViewModel
    {
        readonly AllergyModel allergy;

        public AllergiesViewModel(AllergyModel _allergy)
        {
            this.allergy = _allergy;
        }

        public int Id { get; set; }

        #region Name of the allergy according to the language selected.
        /// <summary>
        /// This property used to display allergy name according to the CultureInfo (Language) used.
        /// if the CultureInfo used is arabic "ar" the Name take NameAr as name of the allergy
        /// if the CultureInfo used is frensh "fr" the Name take NameFr as name of the allergy
        /// if the CultureInfo used is english "en" the Name take NameEn as name of the allergy
        /// </summary>
        public string Name
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? allergy.NameAr : (AppResources.Culture.Name == "fr" ? allergy.NameFr : allergy.NameEn);
                }
                else
                {
                    return allergy.NameEn;
                }
            }
        }

        /// <summary>
        ///  arabic name of the allergy
        /// </summary>
        public string NameAr
        {
            get { return allergy.NameAr; }
            set
            {
                if (allergy.NameAr != value)
                {
                    allergy.NameAr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Frensh name of the allergy
        /// </summary>
        public string NameFr
        {
            get { return allergy.NameFr; }
            set
            {
                if (allergy.NameFr != value)
                {
                    allergy.NameFr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        ///  English name of the allergy
        /// </summary>
        public string NameEn
        {
            get { return allergy.NameEn; }
            set
            {
                if (allergy.NameEn != value)
                {
                    allergy.NameEn = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion


        #region Property to identify the selected allergy
        /// <summary>
        ///  Indicate the allergy selected by the customer
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
