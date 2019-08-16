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
    public partial class OrderPage : MasterDetailPage
    {
        public OrderPage()
        {
            InitializeComponent();
            FlowDirection = FlowDirection.RightToLeft;
            Master.FlowDirection = FlowDirection.RightToLeft;
            Detail = new NavigationPage(new ServicesPage());
        }

    }
}