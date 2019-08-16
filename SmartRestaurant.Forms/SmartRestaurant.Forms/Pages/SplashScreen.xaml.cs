using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            InitializeComponent();
          
        }

        private async void On_Appearing(object sender, EventArgs e)
        {
            await Task.Delay(100);
            App.Current.MainPage = new EnterPage();
            //await WaitAndExecute(2000, () =>
            //App.Current.MainPage = new MainPage()
            //{


            //    Detail = new NavigationPage(new EnterPage())
            //    {
            //        BarBackgroundColor = Color.Transparent,
            //        BackgroundColor = Color.Transparent
            //    },
            //    BackgroundImageSource = "background.jpg",

            //}

            //);
        }
           
                   

        protected async Task WaitAndExecute(int milisec, Action actionToExecute)

        {

            await Task.Delay(milisec);

            actionToExecute();

        }
    }
}