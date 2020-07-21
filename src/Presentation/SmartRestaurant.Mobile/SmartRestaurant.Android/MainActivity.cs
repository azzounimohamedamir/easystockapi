using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;
using Java.Lang.Reflect;
using Android.Graphics;
using Android.Content;
using Android.Util;
using CarouselView.FormsPlugin.Android;
using Xamarin.Forms;
using PanCardView.Droid;
using System.Net;
using System.IO;
using Android.Media;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;

namespace SmartRestaurant.Diner.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            Forms.SetFlags("FastRenderers_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CardsViewRenderer.Preserve();
            Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            App.ParentWindow = this;
            LoadApplication(new App());           
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool CheckAppPermissions()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                return true;
            }

            if (!(ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted) && !(ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) == (int)Permission.Granted))
            {
                var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                ActivityCompat.RequestPermissions(this, permissions, 0);
                return false;
            }
            return true;

        }
    }
}