using SmartRestaurant.Forms.ViewModels;
using SmartRestaurant.Views.Login;
using SmartRestaurant.Views.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        ViewModelLocator locator = Xamarin.Forms.Application.Current.Resources["Locator"] as ViewModelLocator;

        public MainPage()
        {
            InitializeComponent();
            this.BackgroundImageSource = "background.jpg";
            var navigation = new NavigationPage(new ServicesPage());
            navigation.BarBackgroundColor = Color.Transparent;
            navigation.BackgroundColor = Color.Transparent;
            Detail = navigation;
         }
      

        private void LogInClick(object sender, EventArgs e)
        {
            this.BackgroundImageSource = "background.jpg"; 
            Detail.Navigation.PushAsync(new LoginPage()); 
            IsPresented = false;
        }

        private void SignUpClick(object sender, EventArgs e)
        {
            //Detail = new NavigationPage(new SignUpPage());
            this.BackgroundImageSource = "background.jpg";
            Detail.Navigation.PushAsync(new SignUpPage());

            IsPresented = false;

        }

        private void MenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selecteditem = (MenuList)e.SelectedItem;
            if (selecteditem == null) return;
             
            var page = new NavigationPage((Page)Activator.CreateInstance(selecteditem.TargetType));
            if (selecteditem.TargetType == typeof(ServicesPage))
            {
                locator.Main.DishPage = page;

            }
            page.Title = selecteditem.Title;
            if (selecteditem.IsMainPage)
            {
                page.BackgroundImageSource = "background.jpg";
                Xamarin.Forms.Application.Current.MainPage = page;
              
            }
            else
            {

                page.BarBackgroundColor = Color.Transparent;
                page.BackgroundColor = Color.Transparent;
                Detail = page;
               Detail.Title = selecteditem.Title;
               this.BackgroundImageSource = "background.jpg";
                
            }
            IsPresented = false;
        }
    }
}