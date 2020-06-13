using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections.Subsections.Currencies.Currencies
{
    public class CurrencyViewModel:SimpleViewModel
    {
        public readonly CurrencyModel Currency;
        
        /// <summary>
        /// Get the CurrencyModel from the Model.
        /// </summary>
        /// <param name="_Currency"></param>
        public CurrencyViewModel(CurrencyModel _Currency)
        {
            this.Currency = _Currency;

        }

        public int Id
        {
            get
            {
                return Currency.Id;
            }
        }
        public float ExchangeRate
        {
            get
            {
                return Currency.ExchangeRate;
            }
        }


        #region Name of the Currency according to the language selected.
        /// <summary>
        /// This property used to display Currency name according to the CultureInfo (Language) used.
        /// if the CultureInfo used is arabic "ar" the Name take NameAr as name of the Currency
        /// if the CultureInfo used is french "fr" the Name take NameFr as name of the Currency
        /// if the CultureInfo used is english "en" the Name take NameEn as name of the Currency
        /// </summary>
        public string Name
        {
            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? Currency.NameAr : (AppResources.Culture.Name == "fr" ? Currency.NameFr : Currency.NameEn);
                }
                else
                {
                    return Currency.NameEn;
                }
            }
        }

        /// <summary>
        /// Arabic name of the Currency
        /// </summary>
        public string NameAr
        {
            get { return Currency.NameAr; }
            set
            {
                if (Currency.NameAr != value)
                {
                    Currency.NameAr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// French name of the Currency.
        /// </summary>
        public string NameFr
        {
            get { return Currency.NameFr; }
            set
            {
                if (Currency.NameFr != value)
                {
                    Currency.NameFr = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// English name of the Currency.
        /// </summary>
        public string NameEn
        {
            get { return Currency.NameEn; }
            set
            {
                if (Currency.NameEn != value)
                {
                    Currency.NameEn = value;
                    RaisePropertyChanged();
                }
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
     




    }
}
