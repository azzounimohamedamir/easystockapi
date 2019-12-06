using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
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

        public int Id { get
            {
                return dish.Id;
            } }
        

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
            get { return new ObservableCollection<string>( dish.Images); }            
        }
        public int EstimatedTime
        {
            get { return dish.EstimatedTime; }
            set
            {
                dish.EstimatedTime = value;
                RaisePropertyChanged();
            }
        }
        public float Price
        {
            get { return dish.Price; }
            set
            {
                dish.Price = value;
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
                foreach(string i in Images)
                {
                    uris.Add(new Uri(i));
                }

                return  uris;
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
        private bool isSelected=false;
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
                return new Command(async () => {
                    try
                    {
                        await ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new DishSelectPage(this));
                    }
                    catch (Exception)
                    {


                    }
                });
            }
        }
        

    }
}
