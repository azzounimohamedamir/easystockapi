using SmartRestaurant.Resources.Xamarin.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Forms.Helpers
{


    [ContentProperty("Text")]
    public class LocExtension : IMarkupExtension
    {
        public static void RefreshCulture()
        {
            if (CurrentCulture == null) return;

            CultureInfo.CurrentCulture = CurrentCulture;
            CultureInfo.CurrentUICulture = CurrentCulture;
        }

        const string ResourceId = "SmartRestaurant.Resources.Xamarin.Client.UIRes";
        public static CultureInfo CurrentCulture;

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            RefreshCulture();
            if (Text == null)
                return null;
            ResourceManager resourceManager = new ResourceManager
                (ResourceId, typeof(UIRes).GetTypeInfo().Assembly);

            var result=resourceManager.GetString(Text, CurrentCulture);
            return result;
        }
    }
}
