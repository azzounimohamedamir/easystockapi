using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using System;
using System.Linq;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections
{
    /// <summary>
    /// Used to manage subsections as a ViewModel
    /// </summary>
    public class SubSectionViewModel: SimpleViewModel
    {
        readonly SubSectionModel subsection;

        /// <summary>
        /// Get the DishModel from the Model.
        /// </summary>
        /// <param name="_subsection"></param>
        public SubSectionViewModel(SubSectionModel _subsection, SectionViewModel _section)
        {
            this.subsection = _subsection;
            Section = _section;
        }

        public int Id { get; set; }
        

        #region Name of the subsection according to the language selected.
        /// <summary>
        /// This property used to display subsection name according to the CultureInfo (Language) used.
        /// if the CultureInfo used is arabic "ar" the Name take NameAr as name of the subsection
        /// if the CultureInfo used is french "fr" the Name take NameFr as name of the subsection
        /// if the CultureInfo used is english "en" the Name take NameEn as name of the subsection
        /// </summary>
        public string Name
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? subsection.NameAr : (AppResources.Culture.Name == "fr" ? subsection.NameFr : subsection.NameEn);
                }
                else
                {
                    return subsection.NameEn;
                }
            }
        }

        /// <summary>
        /// Arabic name of the subsection
        /// </summary>
        public string NameAr
        {
            get { return subsection.NameAr; }
            set
            {
                if (subsection.NameAr != value)
                {
                    subsection.NameAr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// French name of the subsection.
        /// </summary>
        public string NameFr
        {
            get { return subsection.NameFr; }
            set
            {
                if (subsection.NameFr != value)
                {
                    subsection.NameFr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// English name of the subsection.
        /// </summary>
        public string NameEn
        {
            get { return subsection.NameEn; }
            set
            {
                if (subsection.NameEn != value)
                {
                    subsection.NameEn = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion


        #region Properties to manage images.
        /// <summary>
        /// Image to indicate the nature of the subsection.
        /// </summary>
        public string Image
        {
            get { return subsection.Image; }
            set
            {
                subsection.Image = value;
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
                return String.IsNullOrEmpty(subsection.Image) ? null : new Uri(Image);
            }
        }
        #endregion
        public DishListViewModel Dishes {

            get { return new DishListViewModel(subsection.SectionId,subsection.Id, this); }
            set
            {
                if (subsection.Dishes != value)
                {                    
                    subsection.Dishes = value.Dishes.Select(t => t.dish).ToList();
                    RaisePropertyChanged();
                }
            }
        }
        public SectionViewModel Section
        {
            get;
            set;           
        }
        public int SectionId
        {
            get { return subsection.SectionId; }
            set
            {
                if (subsection.SectionId != value)
                {
                    subsection.SectionId = value;
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
        public TextAlignment OppositeOrientationText
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? TextAlignment.Start : TextAlignment.End;
                }
                else
                {
                    return TextAlignment.Start;
                }
            }
        }
        public bool IsVisible { get; set; }

    }
}
