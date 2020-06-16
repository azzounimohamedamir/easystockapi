using Xamarin.Forms;

namespace SmartRestaurant.Diner.CustomControls
{
    public class CustomNavigationPage: NavigationPage
    {
        public CustomNavigationPage(Page root) : base(root)
        {
            BarBackgroundColor = Color.FromHex("#E0E0E0");
            BarTextColor = Color.Black;
        }
    }
}
