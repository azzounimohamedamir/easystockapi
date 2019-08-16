#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SmartRestaurant.Application.Identity;
using SmartRestaurant.Forms;
using SmartRestaurant.Forms.Helpers;
using SmartRestaurant.Forms.Services;
using SmartRestaurant.Forms.ViewModels;
using SmartRestaurant.Views.Login;
using System;
using Xamarin.Forms;

namespace SmartRestaurant.ViewModels.SignUp
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    public class SignUpPageViewModel : BaseViewModel
    {
        ViewModelLocator Locator = Xamarin.Forms.Application.Current.Resources["Locator"] as ViewModelLocator;

        public INavigation Navigation { get; set; }

        public SignUpPageViewModel(INavigation navigation)
        {
            LoginCommand = new Command(LoginClicked);
            SignUpCommand = new Command(SignUpClicked);
            Navigation = navigation;
        }

        /// <summary>
        /// This property is bound with an entry that gets the name from the user in the sign-up page.
        /// </summary>
        public string Name { get; set; }



        /// <summary>
        /// This property is bound with an entry that gets the password from the user in the sign-up page.
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// This property is bound with an entry that gets the password confirmation from the user in the sign-up page.
        /// </summary>
        public string ConfirmPassword { get; set; }


        /// <summary>
        /// This command is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// This command is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        private async void LoginClicked(object obj)

        {
            await Navigation.PushAsync(new LoginPage()); 


        }

        private async void SignUpClicked(object obj)
        {
            try
            {

                LoginService loginService = new LoginService();

                RegisterModel registerModel = new RegisterModel
                {
                    Username = Name,
                    FirstName = Name,
                    LastName = Name,
                    Email = Email,
                    Password = Password,
                    PasswordConfirmation = ConfirmPassword,
                    RoleName = "Guest"
                };
               var accesstoken =  await loginService.RegisterAsync(registerModel);
               Settings.AccessToken = accesstoken;
                Settings.username = registerModel.Username;
                Settings.password = registerModel.Password;


              
            }
            catch (Exception ex)

            {
                throw ex;
            }






        }

        /// <summary>
        /// This property is bound with an entry that gets the email ID from the user in the login page.
        /// </summary>
        public string Email { get; set; }



        /// <summary>
        /// Gets or sets the value indicating whether the entered email is valid or invalid.
        /// </summary>
        public bool IsInvalidEmail { get; set; }
    }
}