using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels
{
    /// <summary>
    /// ViewModel of the Login view.
    /// </summary>
    public class PasswordViewModel: SimpleViewModel
    {

        #region Properties to manage password
        /// <summary>
        /// the password is constructed of 04 numeric chars every char has it's own textbox.
        /// when a char is changed theses four chars are collected to form our password and check if it's the user has enter the right password.
        /// </summary>
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                SetPropertyValue(ref password, value);
                if (password.Trim().Length == 4)
                {
                    ProcessPassword();
                }
            }
        }

        /// <summary>
        /// The first char used to form the password.
        /// </summary>
        private string firstChar;
        public string FirstChar
        {
            get
            {
                return firstChar;
            }
            set
            {
                SetPropertyValue(ref firstChar, value);
                
                //Check if the four chars are not null to construct the password.
                if ((FirstChar != null) && (SecondChar != null) && (ThirdChar != null) && (FourthChar != null))
                {
                    Password = FirstChar + SecondChar + ThirdChar + FourthChar;
                }
            }
        }

        /// <summary>
        /// The second char used to form the password.
        /// </summary>
        private string secondChar;
        public string SecondChar
        {
            get
            {
                return secondChar;
            }
            set
            {
                SetPropertyValue(ref secondChar, value);
                //Check if the four chars are not null to construct the password.
                if ((FirstChar != null) && (SecondChar != null) && (ThirdChar != null) && (FourthChar != null))
                {
                    Password = FirstChar + SecondChar + ThirdChar + FourthChar;
                }
            }
        }

        /// <summary>
        /// The third char used to form the password.
        /// </summary>
        private string thirdChar;
        public string ThirdChar
        {
            get
            {
                return thirdChar;
            }
            set
            {
                SetPropertyValue(ref thirdChar, value);
                //Check if the four chars are not null to construct the password.
                if ((FirstChar != null) && (SecondChar != null) && (ThirdChar != null) && (FourthChar != null))
                {
                    Password = FirstChar + SecondChar + ThirdChar + FourthChar;
                }
            }
        }

        /// <summary>
        /// The fourth char used to form the password
        /// </summary>
        private string fourthChar;
        public string FourthChar
        {
            get
            {
                return fourthChar;
            }
            set
            {
                SetPropertyValue(ref fourthChar, value);
                //Check if the four chars are not null to construct the password.
                if ((FirstChar != null) && (SecondChar != null) && (ThirdChar != null) && (FourthChar != null))
                {
                    Password = FirstChar + SecondChar + ThirdChar + FourthChar;
                }
            }
        }
        #endregion


        #region Methode to check password and navigate to the next page.
        /// <summary>
        /// Function to check if the password is correct and then navigate to the language view.
        /// Else ask the user to try again.
        /// </summary>
        public void ProcessPassword()
        {
            // In the beguening the password is set to "0000" before implementing the fonctionnalite to change it
            string pw = GetPassword().Result;
            if ((pw == password)|| (password == "0000"))
            {
                App.Current.MainPage = new CustomNavigationPage(new ZonesAndTablesPage(new ViewModels.Zones.ZonesListViewModel()));
                 
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    FirstChar = "";
                    SecondChar = "";
                    ThirdChar = "";
                    FourthChar = "";
                    bool answer = await App.Current.MainPage.DisplayAlert("Password", "Wrong password, try again.", "Yes", "No");
                    if (!answer)
                    {
                        App.Current.Quit();
                    }
                });
            }
        }

        #endregion


        #region methods to store and get password from local storage.
        /// <summary>
        /// Function to store the password in Local Storage of the system
        /// </summary>
        public async void SetPassword()
        {
            try
            {
                await SecureStorage.SetAsync("srpassword", Password);
            }
            catch (Exception)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        /// <summary>
        /// Function to get the password from the Local Storage.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPassword()
        {
            try
            {
                var pw = await SecureStorage.GetAsync("srpassword");
                if (pw == null)
                {
                    await SecureStorage.SetAsync("srpassword", Password);
                    pw = SecureStorage.GetAsync("srpassword").Result;
                }
                return pw;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
