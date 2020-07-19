using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.ViewModels;
using SmartRestaurant.Diner.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartRestaurant.Diner
{
    public partial class App : Application
    {
        public static string base_url_images = "https://raw.githubusercontent.com/khaireddineGHP/ImagesForSmartRestaurant/master/";
        public static Object ParentWindow;

        public App()
        {
            InitializeComponent();
            if (DeviceInfo.Platform.ToString() == Device.Android)
            {
                DependencyService.Get<ICheckFilePermission>().CheckPermission();
            }

            //Launch the first Page.
            MainPage = new CustomNavigationPage(new PasswordPage(new PasswordViewModel()));
        }

        protected override void OnStart()
        {
            // Handle when your app starts

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
