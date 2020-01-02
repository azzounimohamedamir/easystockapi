using Plugin.Multilingual;
using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Views;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels
{
    /// <summary>
    /// Used to Bind with the language View and to select a language.
    /// </summary>
    public class LanguageViewModel: SimpleViewModel
    {

        public LanguageViewModel()
        {
        }

        #region Language properties.
        private bool arabicLanguage;
        public bool ArabicLanguage
        {
            get 
            {
                return arabicLanguage;
            }
            set
            {
                SetPropertyValue(ref arabicLanguage, value);

                // if Arabic language is selected then update the color of the background and border of the rectangle according to it
                // and uncheck the french and english language.
                if (arabicLanguage == true)
                {
                    FrenchLanguage = false;
                    EnglishLanguage = false;

                    ArabicColor = Color.FromHex("#F2FBFB");
                    ArabicColorBorder = Color.FromHex("#3CBDBF");
                }
                else
                {
                    ArabicColor = Color.FromHex("#FFFFFF");
                    ArabicColorBorder = Color.FromHex("#EEEEEE");
                }
                SetLanguage();
            }
        }

        private bool frenchLanguage;
        public bool FrenchLanguage
        {
            get
            {
                return frenchLanguage;
            }
            set
            {
                SetPropertyValue(ref frenchLanguage, value);
                // if French language is selected then update the color of the background and border of the rectangle according to it
                // and uncheck the arabic and english language.
                if (frenchLanguage == true)
                {
                    ArabicLanguage = false;
                    EnglishLanguage = false;

                    FrenchColor = Color.FromHex("#F2FBFB");
                    FrenchColorBorder = Color.FromHex("#3CBDBF");
                }
                else
                {
                    FrenchColor = Color.FromHex("#FFFFFF");
                    FrenchColorBorder = Color.FromHex("#EEEEEE");
                }
                SetLanguage();
            }
        }

        private bool englishLanguage;
        public bool EnglishLanguage
        {
            get
            {
                return englishLanguage;
            }
            set
            {
                SetPropertyValue(ref englishLanguage, value);
                // if English language is selected then update the color of the background and border of the rectangle according to it
                // and uncheck the arabic and french language.
                if (englishLanguage == true)
                {
                    ArabicLanguage = false;
                    FrenchLanguage = false;

                    EnglishColor = Color.FromHex("#F2FBFB");
                    EnglishColorBorder = Color.FromHex("#3CBDBF");
                }
                else
                {
                    EnglishColor = Color.FromHex("#FFFFFF");
                    EnglishColorBorder = Color.FromHex("#EEEEEE"); ;
                }
                SetLanguage();
            }
        }
        #endregion


        #region Backgroud color
        //Used to change Background color of the arabic CardView 
        private Color arabicColor;
        public Color ArabicColor
        {
            get
            {
                return arabicColor;
            }
            set
            {
                SetPropertyValue(ref arabicColor, value);
            }
        }

        //Used to change Background color of the french CardView
        private Color frenchColor;
        public Color FrenchColor
        {
            get
            {
                return frenchColor;
            }
            set
            {
                SetPropertyValue(ref frenchColor, value);
            }
        }

        //Used to change Background color of the english CardView
        private Color englishColor;
        public Color EnglishColor
        {
            get
            {
                return englishColor;
            }
            set
            {
                SetPropertyValue(ref englishColor, value);
            }
        }
        #endregion


        #region Border color
        //Used to change Background color of the arabic CardView
        private Color arabicColorBorder;
        public Color ArabicColorBorder
        {
            get
            {
                return arabicColorBorder;
            }
            set
            {
                SetPropertyValue(ref arabicColorBorder, value);
            }
        }

        //Used to change Background color of the french CardView
        private Color frenchColorBorder;
        public Color FrenchColorBorder
        {
            get
            {
                return frenchColorBorder;
            }
            set
            {
                SetPropertyValue(ref frenchColorBorder, value);
            }
        }

        //Used to change Background color of the english CardView
        private Color englishColorBorder;
        public Color EnglishColorBorder
        {
            get
            {
                return englishColorBorder;
            }
            set
            {
                SetPropertyValue(ref englishColorBorder, value);
            }
        }
        #endregion


        #region Method to set language
        // Command to set language for the app.
        public ICommand SetLanguageCommande
        {
            get
            {
                return new Command(() => SetLanguage());
            }
        }

        /// <summary>
        /// Fonction used to set CultureInfo of the app and change language.
        /// </summary>
        public void SetLanguage()
        {
            string language = "fr";
            language = EnglishLanguage ? "en" : (ArabicLanguage ? "ar" : "fr");
            
            var culture = new CultureInfo(language);
            AppResources.Culture = culture;
            CrossMultilingual.Current.CurrentCultureInfo = culture;
            
            var stack = App.Current.MainPage.Navigation.NavigationStack;
            var typeLastElement = stack[stack.Count - 1].GetType();
            if (typeLastElement != typeof(WelcomePage))
            {
                  ((CustomNavigationPage)(App.Current.MainPage)).PushAsync(new WelcomePage(new WelcomeViewModel()));
                
            }
        }
        #endregion


        #region Command to select language on tap event
        /// <summary>
        /// Command used to select the language of the app.
        /// </summary>
        public ICommand SelectLanguage
        {
            get
            {
                return new Command<string>((x) => {
                    switch(x)
                    {
                        case "ar":
                            ArabicLanguage = true;
                            break;
                        case "fr":
                            FrenchLanguage = true;
                            break;
                        case "en":
                            EnglishLanguage = true;
                            break;
                    }
                });
            }
        }
        #endregion

    }
}
