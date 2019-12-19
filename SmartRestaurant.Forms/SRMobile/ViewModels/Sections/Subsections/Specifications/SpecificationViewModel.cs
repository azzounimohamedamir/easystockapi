using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections.Subsections.Specificationes.Specifications
{
    public class SpecificationViewModel:SimpleViewModel
    {
        public readonly SpecificationModel Specification;
        
        /// <summary>
        /// Get the SpecificationModel from the Model.
        /// </summary>
        /// <param name="_Specification"></param>
        public SpecificationViewModel(SpecificationModel _Specification)
        {
            this.Specification = _Specification;

        }

        public int Id
        {
            get
            {
                return Specification.Id;
            }
        }

      


        #region Name of the Specification according to the language selected.
        /// <summary>
        /// This property used to display Specification name according to the CultureInfo (Language) used.
        /// if the CultureInfo used is arabic "ar" the Name take NameAr as name of the Specification
        /// if the CultureInfo used is frensh "fr" the Name take NameFr as name of the Specification
        /// if the CultureInfo used is english "en" the Name take NameEn as name of the Specification
        /// </summary>
        public string Name
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? Specification.NameAr : (AppResources.Culture.Name == "fr" ? Specification.NameFr : Specification.NameEn);
                }
                else
                {
                    return Specification.NameEn;
                }
            }
        }

        /// <summary>
        /// Arabic name of the Specification
        /// </summary>
        public string NameAr
        {
            get { return Specification.NameAr; }
            set
            {
                if (Specification.NameAr != value)
                {
                    Specification.NameAr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// French name of the Specification.
        /// </summary>
        public string NameFr
        {
            get { return Specification.NameFr; }
            set
            {
                if (Specification.NameFr != value)
                {
                    Specification.NameFr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// English name of the Specification.
        /// </summary>
        public string NameEn
        {
            get { return Specification.NameEn; }
            set
            {
                if (Specification.NameEn != value)
                {
                    Specification.NameEn = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Possible Specification Values of the Specification according to the language selected.
        /// <summary>
        /// This property used to display Possible Specification Values name according to the CultureInfo (Language) used.
        /// </summary>
        public List<string> Possible_Values
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? Specification.Possible_ValuesAr : (AppResources.Culture.Name == "fr" ? Specification.Possible_ValuesFr : Specification.Possible_ValuesEn);
                }
                else
                {
                    return Specification.Possible_ValuesEn;
                }
            }
        }

        /// <summary>
        /// French names of the Possible values
        /// </summary>
        public List<string> Possible_ValuesFr
        {
            get { return Specification.Possible_ValuesFr; }
            set
            {

                    Specification.Possible_ValuesFr = value;
                    RaisePropertyChanged();
                
            }
        }

        /// <summary>
        /// English names of the Possible values
        /// </summary>
        public List<string> Possible_ValuesEn
        {
            get { return Specification.Possible_ValuesEn; }
            set
            {

                Specification.Possible_ValuesEn = value;
                RaisePropertyChanged();

            }
        }

        #endregion
        private ObservableCollection<RadioOption> _RadioOptionsVM;
        public ObservableCollection<RadioOption> RadioOptionsVM
        {
            get
            {
                if(_RadioOptionsVM==null)
                {
                    _RadioOptionsVM = new ObservableCollection<RadioOption>();
                    foreach(string p in Possible_Values)
                    {
                        _RadioOptionsVM.Add(new RadioOption(p, false));
                    }
                    if(_RadioOptionsVM.Count>0)
                    _RadioOptionsVM[0].IsSelected = true;
                }
                return _RadioOptionsVM;
            }
            set
            {
                _RadioOptionsVM = value;
                RaisePropertyChanged();
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
    }
}
