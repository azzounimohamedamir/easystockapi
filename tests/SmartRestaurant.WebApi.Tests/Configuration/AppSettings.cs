using System.Net;

namespace SmartRestaurant.WebApi.Tests.Configuration
{
    public class AppSettings
    {
        public const string LocalApiEndpoint = "http://localhost:5000/api";
        public const string RemoteApiEndpoint = "http://test.smartrestaurant.io/api";

        public static string GetApiEndpoint()
        {
            return IsWebsiteLive(LocalApiEndpoint) ? LocalApiEndpoint : RemoteApiEndpoint;
        }

        private static bool IsWebsiteLive(string url)
        {
            var request = WebRequest.Create(url);
            try
            {
                request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}