using SmartRestaurant.Forms.Pages;
using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Forms
{
    public partial class App : Xamarin.Forms.Application
    {
     
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA1MDgzQDMxMzcyZTMxMmUzMFQrV0RJeEpIU21pcW51dHBncThvZHBpWndvSHlURkEyazlESytqNGdVVkE9");

            InitializeComponent();

            var main = new SplashScreen(); 
            MainPage = main;
          
       
        }

        protected override void OnStart()
        {
           
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
