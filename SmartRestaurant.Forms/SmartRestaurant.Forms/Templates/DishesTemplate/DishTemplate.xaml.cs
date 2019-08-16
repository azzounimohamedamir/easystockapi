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
    public partial class DishTemplate : ViewCell
    {
        public DishTemplate()
        {
           
                InitializeComponent();
   
            //numericUpDown.Culture = new System.Globalization.CultureInfo("ar-DZ");

        }

        public static readonly BindableProperty ParentContextProperty =
        BindableProperty.Create("ParentContext", typeof(object), typeof(DishTemplate), null, propertyChanged: OnParentContextPropertyChanged);

        public object ParentContext
        {
            get { return GetValue(ParentContextProperty); }
            set { SetValue(ParentContextProperty, value); }
        }

        private static void OnParentContextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != oldValue && newValue != null)
            {
                (bindable as DishTemplate).ParentContext = newValue;
            }
        }



        public static readonly BindableProperty CommandsProperty = BindableProperty.Create(nameof(Commands), typeof(object), typeof(DishTemplate));

        public object Commands
        {
            get => GetValue(CommandsProperty);
            set => SetValue(CommandsProperty, value);
        }


      

    }
}