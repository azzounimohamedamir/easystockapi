using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Multilingual;
using SmartRestaurant.Diner.Droid.CustomControlsRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Application = Android.App.Application;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(SmartRestaurant.Diner.CustomControls.CustomNavigationPage), typeof(CustomNavigationPageRenderer))]

namespace SmartRestaurant.Diner.Droid.CustomControlsRenderers
{  
        public class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        private Android.Support.V7.Widget.Toolbar toolbar;

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);
            if (child.GetType() == typeof(Android.Support.V7.Widget.Toolbar))
            {
                toolbar = (Android.Support.V7.Widget.Toolbar)child;
                toolbar.ChildViewAdded += Toolbar_ChildViewAdded;
                toolbar.SetMinimumHeight(117);
            }
        }

        private void Toolbar_ChildViewAdded(object sender, ChildViewAddedEventArgs e)
        {
            var view = e.Child.GetType();
            if (e.Child.GetType() == typeof(Android.Support.V7.Widget.AppCompatTextView))
            {
                var textView = (Android.Support.V7.Widget.AppCompatTextView)e.Child;
                var t = textView.Text;
                var spaceFont = Typeface.CreateFromAsset(Application.Context.Assets, "Fonts/Roboto.ttf");
                textView.Typeface = spaceFont;
                textView.SetHeight(117);
                textView.SetWidth(800);
                
                if (CrossMultilingual.Current.CurrentCultureInfo.Name == "ar")
                {
                    textView.SetPadding(0, 15, 106, 15);
                    textView.LayoutDirection = LayoutDirection.Rtl;
                    textView.TextDirection = TextDirection.Rtl;
                }
                else
                {
                    textView.SetPadding(106, 15, 0, 15);
                    textView.LayoutDirection = LayoutDirection.Ltr;
                    textView.TextDirection = TextDirection.Ltr;
                }
                

                textView.TextSize = 20;
                textView.SetTextColor(Android.Graphics.Color.Black);
                
                toolbar.ChildViewAdded -= Toolbar_ChildViewAdded;
            }
        }
    }
}