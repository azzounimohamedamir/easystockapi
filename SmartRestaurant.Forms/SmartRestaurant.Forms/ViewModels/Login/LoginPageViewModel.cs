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
using SmartRestaurant.Views.SignUp;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartRestaurant.ViewModels.Login
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    /// 
    public class LoginPageViewModel : BaseViewModel
    {
     
        public INavigation Navigation;

        public LoginPageViewModel(INavigation navigation)
        {
            LoginCommand = new Command(LoginClicked);
            SignUpCommand = new Command(SignUpClicked);
            ForgotPasswordCommand = new Command(ForgotPasswordClicked);
            SocialMediaLoginCommand = new Command(SocialLoggedIn);
            UserName = Settings.username;
            Password = Settings.password;
            Navigation = navigation; 
        }

        /// <summary>
        /// This property is bound with an entry that gets the password from the user in the login page.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// This property is bound with an entry that gets the password from the user in the login page.
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// This command is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// This command is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// This command is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// This command is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        private async  void LoginClicked(object obj)
        {
            try
            {

                LoginService loginService = new LoginService();

                LoginModel loginModel = new LoginModel
                {
                    Username = UserName,
                    
                    Password = Password,
                   
                    RoleName = "Guest"
                };
                var accesstoken = await loginService.LoginAsync(loginModel);
                Settings.AccessToken = accesstoken.ToString();
                if(accesstoken != null )
                {
                    await Navigation.PopAsync();
                }



            }
            catch (Exception ex)

            {
                throw ex;
            }

        }

        private async void SignUpClicked(object obj)
        {
           await Navigation.PushAsync(new SignUpPage());
        }

        private void ForgotPasswordClicked(object obj)
        {

        }

        private void SocialLoggedIn()
        {

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