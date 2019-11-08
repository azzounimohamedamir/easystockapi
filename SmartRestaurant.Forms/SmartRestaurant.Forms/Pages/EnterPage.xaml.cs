using SmartRestaurant.Application.Commun.Languages.Factory;
using SmartRestaurant.Forms.Helpers;
using SmartRestaurant.Forms.Interfaces;
using SmartRestaurant.Forms.Pages;
using SmartRestaurant.Forms.ViewModels;
using SmartRestaurant.Resources.Xamarin.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace SmartRestaurant.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterPage : ContentPage
    {
        private EnterViewModel viewModel;
        static private bool _isExecutedFirst = false;

        ViewModelLocator Locator = Xamarin.Forms.Application.Current.Resources["Locator"] as ViewModelLocator;
        public EnterPage()
        {
            InitializeComponent();
            this.BackgroundImageSource = "background.jpg";
            viewModel = BindingContext as EnterViewModel;
             

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //// geet labels from resources 
               await  viewModel.GetLaguagesAsync();

            //LanguagesLabels();


        }

        //private   void  LanguagesLabels()
        //{




        //    if (!_isExecutedFirst)
        //    {
        //       var LabelAR = new Label()
        //    {
        //        Text = "أختر لغتك",
        //        TextColor = Color.White,
        //        HorizontalOptions = LayoutOptions.Center,
        //        FontSize = 20,
        //        FontAttributes = FontAttributes.Bold,
        //        FontFamily = "Segoe UI",


        //    };
        //    var LabelEN = new Label()
        //    {
        //        Text = "choose your Languages",
        //        TextColor = Color.White,
        //        HorizontalOptions = LayoutOptions.Center,
        //        FontSize = 20,
        //        FontAttributes = FontAttributes.Bold,
        //        FontFamily = "Segoe UI",

        //    };
        //    var LabelFR = new Label()
        //    {
        //        Text = "choisir voter Langauge",
        //        TextColor = Color.White,
        //        FontAttributes = FontAttributes.Bold,
        //        HorizontalOptions = LayoutOptions.Center,
        //        FontSize = 20,
        //        FontFamily = "Segoe UI",

        //    };
        //     LanguagesPannel.Children.Add(LabelAR);
        //    LanguagesPannel.Children.Add(LabelEN);
        //    LanguagesPannel.Children.Add(LabelFR);
        //        _isExecutedFirst = true;
        //    }
              
        //}

        private async void OrderButton_Clicked(object sender, EventArgs e)
        {
            await NavigateToMenue();
        }

        private async Task NavigateToMenue()
        {
            //BusyIndicator.IsBusy = true;
            var culture = new CultureInfo("en-US");
            var lagIso = viewModel?.SelectedLanguage.CultureIso ?? EnumLaguangeIso.En;
            //// getting value with languages 




            switch (lagIso)
            {
                case EnumLaguangeIso.Ar:
                    culture = new CultureInfo("ar-DZ");
                    break;
                case EnumLaguangeIso.Fr:
                    culture = new CultureInfo("fr-FR");
                    break;
                default:
                    break;
            }
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            LocExtension.CurrentCulture = culture;
            Locator.Main.RefreshMenuItems();
            XamarinH.ChangeRessource("Flow", lagIso.ToString());

            Xamarin.Forms.Application.Current.MainPage = new MainPage();
            await Task.Delay(100);
            //BusyIndicator.IsBusy = false;
        }

        private async void Chairs_Clicked(object sender, EventArgs e)
        {
          await NavigateToMenue();
            //var ScannerPage = new ZXingScannerPage();

            //ScannerPage.OnScanResult += (result) =>
            //{

            //    ScannerPage.IsScanning = false;

            //    Device.BeginInvokeOnMainThread(async () =>
            //    {
            //        await Navigation.PopAsync();
            //        viewModel.SelectedChair = result.Text;
            //        await NavigateToMenue();
            //    });
            //};
            //await Navigation.PushAsync(ScannerPage);

        }

        private void Languageslist_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {

        }
    }


    public class ChoosingLanguages
    {

        public EnumLaguangeIso EnumLaguangeIso { get; set; }
        public string SelectedLanguages { get; set;  }
    }

}