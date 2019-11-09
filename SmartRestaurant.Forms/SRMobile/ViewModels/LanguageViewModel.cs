using Plugin.Multilingual;
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
                // and uncheck the frensh and english language.
                if (arabicLanguage == true)
                {
                    FrenshLanguage = false;
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

        private bool frenshLanguage;
        public bool FrenshLanguage
        {
            get
            {
                return frenshLanguage;
            }
            set
            {
                SetPropertyValue(ref frenshLanguage, value);
                // if Frensh language is selected then update the color of the background and border of the rectangle according to it
                // and uncheck the arabic and english language.
                if (frenshLanguage == true)
                {
                    ArabicLanguage = false;
                    EnglishLanguage = false;

                    FrenshColor = Color.FromHex("#F2FBFB");
                    FrenshColorBorder = Color.FromHex("#3CBDBF");
                }
                else
                {
                    FrenshColor = Color.FromHex("#FFFFFF");
                    FrenshColorBorder = Color.FromHex("#EEEEEE");
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
                // and uncheck the arabic and frensh language.
                if (englishLanguage == true)
                {
                    ArabicLanguage = false;
                    FrenshLanguage = false;

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

        //Used to change Background color of the frensh CardView
        private Color frenshColor;
        public Color FrenshColor
        {
            get
            {
                return frenshColor;
            }
            set
            {
                SetPropertyValue(ref frenshColor, value);
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

        //Used to change Background color of the frensh CardView
        private Color frenshColorBorder;
        public Color FrenshColorBorder
        {
            get
            {
                return frenshColorBorder;
            }
            set
            {
                SetPropertyValue(ref frenshColorBorder, value);
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
                App.Current.MainPage.Navigation.PushAsync(new WelcomePage(new WelcomeViewModel()));
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
                            FrenshLanguage = true;
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
