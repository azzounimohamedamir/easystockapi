using Android.Views;
using Plugin.Multilingual;
using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Droid.CustomControlsRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]
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
            }
        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            if (CrossMultilingual.Current.CurrentCultureInfo.Name == "ar")
            {
                LayoutDirection = LayoutDirection.Rtl;
                TextDirection = TextDirection.Rtl;
            }
            else
            {
                LayoutDirection = LayoutDirection.Ltr;
                TextDirection = TextDirection.Ltr;
            }
        }
        private void Toolbar_ChildViewAdded(object sender, ChildViewAddedEventArgs e)
        {
            var view = e.Child.GetType();
            if (e.Child.GetType() == typeof(Android.Support.V7.Widget.AppCompatTextView))
            {
                var textView = (Android.Support.V7.Widget.AppCompatTextView)e.Child;
                if (CrossMultilingual.Current.CurrentCultureInfo.Name == "ar")
                {
                    textView.LayoutDirection = LayoutDirection.Rtl;
                    textView.TextDirection = TextDirection.Rtl;
                }
                else
                {
                    textView.LayoutDirection = LayoutDirection.Ltr;
                    textView.TextDirection = TextDirection.Ltr;
                }
            }
        }
    }
}