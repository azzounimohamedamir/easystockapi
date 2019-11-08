#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using SmartRestaurant.ViewModels.SignUp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Views.SignUp
{
    /// <summary>
    /// Page to sign in with user details.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            this.BindingContext = new SignUpPageViewModel(Navigation);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Device.Idiom != TargetIdiom.Desktop)
            {
                if (width > height)
                {
                    rootView.Margin = (Device.Idiom == TargetIdiom.Phone)
                        ? new Thickness(150, 20)
                        : new Thickness(300, 50);
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        BackgroundImageSource = "background.jpg";
                    }
                }
                else
                {
                    rootView.Margin = (Device.Idiom == TargetIdiom.Phone)
                        ? new Thickness(20, 20)
                        : new Thickness(200, 50);
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        BackgroundImageSource = "background.jpg";
                    }
                }
            }
            else
            {
                rootView.WidthRequest = 350;
                rootView.Margin = new Thickness(30);
            }
        }
    }
}