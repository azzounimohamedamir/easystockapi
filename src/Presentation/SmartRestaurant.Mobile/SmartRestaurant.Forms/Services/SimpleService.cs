using System.IO;
using System.Reflection;

namespace SmartRestaurant.Diner.Services
{
    public class SimpleService
    {
        public static string GetJsonString(string jsonFileName)
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();
                return jsonString;
            }
        }
    }
}
