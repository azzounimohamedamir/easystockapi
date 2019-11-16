using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.CustomControls
{
    public class CustomNavigationPage: NavigationPage
    {
        public CustomNavigationPage(Page root) : base(root)
        {
            BarBackgroundColor = Color.FromRgba(0, 0, 0, 0.3);
            BarTextColor = Color.Black;
            
        }
    }
}
