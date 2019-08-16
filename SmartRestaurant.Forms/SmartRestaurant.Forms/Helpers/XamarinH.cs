using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SmartRestaurant.Forms.Helpers
{
    public static class XamarinH
    {
        public static void ChangeRessource(string defaultName, string languageIso)
        {
            // List all our resources      
            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            foreach (ResourceDictionary dictionary in Xamarin.Forms
                .Application.Current.Resources.MergedDictionaries)
            {
                dictionaryList.Add(dictionary);
            }
            // We want our specific culture      
            string requestedCulture = $"{defaultName}{languageIso}";

            var resourceDictionary = dictionaryList.FirstOrDefault(d => d.GetType().Name == requestedCulture);
            if (resourceDictionary == null)
            {
                resourceDictionary = dictionaryList.FirstOrDefault(d => d.GetType().Name == defaultName);
            }
            if (resourceDictionary != null)
            {
                Xamarin.Forms.Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
                Xamarin.Forms.Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }

        }
    }
}
