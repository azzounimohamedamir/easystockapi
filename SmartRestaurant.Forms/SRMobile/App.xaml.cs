using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.ViewModels;
using SmartRestaurant.Diner.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Launch the first Page.

            //MainPage = new CustomNavigationPage(new PasswordPage(new PasswordViewModel()));
            MainPage=new  CustomNavigationPage(new SectionsPage(new ViewModels.Sections.SectionsListViewModel()));

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
