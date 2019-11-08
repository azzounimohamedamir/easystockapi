using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Forms.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductTemplate : ViewCell
    {
        public ProductTemplate()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ParentContextProperty =
  BindableProperty.Create("ParentContext", typeof(object), typeof(ProductTemplate), null, propertyChanged: OnParentContextPropertyChanged);

        public object ParentContext
        {
            get { return GetValue(ParentContextProperty); }
            set { SetValue(ParentContextProperty, value); }
        }

        private static void OnParentContextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != oldValue && newValue != null)
            {
                (bindable as ProductTemplate).ParentContext = newValue;
            }
        }



        public static readonly BindableProperty CommandsProperty = BindableProperty.Create(nameof(Commands), typeof(object), typeof(ProductTemplate));

        public object Commands
        {
            get => GetValue(CommandsProperty);
            set => SetValue(CommandsProperty, value);
        }


    }
}