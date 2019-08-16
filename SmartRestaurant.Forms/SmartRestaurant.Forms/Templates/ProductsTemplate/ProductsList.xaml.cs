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
    public partial class ProductsList : ContentView
    {
        public ProductsList()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ItemsProperty =
        BindableProperty.Create("Items", typeof(object), typeof(ProductsList), null, propertyChanged: OnItemsPropertyChanged);

        public object Items
        {
            get { return GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        private static void OnItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != oldValue && newValue != null)
            {
                (bindable as ProductsList).Items = newValue;
            }
        }

    }
}