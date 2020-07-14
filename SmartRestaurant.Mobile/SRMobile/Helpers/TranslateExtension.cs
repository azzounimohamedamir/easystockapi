using Plugin.Multilingual;
using System;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner.Helpers
{
    /// <summary>
    /// This class is used by the plugin Multilingual to translate texts of the UI according to the languages resources installed
    /// so for that each sentenses in the UI has a <key:value> in the three resources languages.
    /// </summary>
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        // the default resource used by the application.
        const string ResourceId = "SmartRestaurant.Diner.Resources.AppResources";

        static readonly Lazy<ResourceManager> resmgr =
            new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";
            try
            {
                var ci = CrossMultilingual.Current.CurrentCultureInfo;

                var translation = resmgr.Value.GetString(Text, ci);

                if (translation == null)
                {

#if DEBUG
                    throw new ArgumentException(
                        String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                        "Text");
#else
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER  
#endif
                }
                return translation;
            }
            catch (Exception)
            {
                return "";
            }

        }
    }
}
