using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Diner.ViewModels.Sections
{
    /// <summary>
    /// Used to manage sections objects as a ViewModel
    /// </summary>
    public class SectionViewModel: SimpleViewModel
    {
        readonly SectionModel section;
        public SectionViewModel(SectionModel _section)
        {
            this.section = _section;
        }

        public int Id { get; set; }


        #region Name of the section according to the language selected.
        /// <summary>
        /// This property used to display section name according to the CultureInfo (Language) used.
        /// if the CultureInfo used is arabic "ar" the Name take NameAr as name of the section
        /// if the CultureInfo used is frensh "fr" the Name take NameFr as name of the section
        /// if the CultureInfo used is english "en" the Name take NameEn as name of the section
        /// </summary>
        public string Name
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? section.NameAr : (AppResources.Culture.Name == "fr" ? section.NameFr : section.NameEn);
                }
                else
                {
                    return section.NameEn;
                }
            }
        }

        /// <summary>
        /// Arabic name of the section
        /// </summary>
        public string NameAr
        {
            get { return section.NameAr; }
            set
            {
                if (section.NameAr != value)
                {
                    section.NameAr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Frensh name of the section.
        /// </summary>
        public string NameFr
        {
            get { return section.NameFr; }
            set
            {
                if (section.NameFr != value)
                {
                    section.NameFr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// English name of the section.
        /// </summary>
        public string NameEn
        {
            get { return section.NameEn; }
            set
            {
                if (section.NameEn != value)
                {
                    section.NameEn = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion


        #region Properties to manage images.
        /// <summary>
        /// Image to indicate the nature of the section.
        /// </summary>
        public string Image 
        {
            get { return section.Image; }
            set
            {
                section.Image = value;
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
                return String.IsNullOrEmpty(section.Image) ? null : new Uri(Image);
            }
        }
        #endregion


        #region Property to select a section.
        /// <summary>
        /// Used to indicate if the section is selected by the user.
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
    }
}
