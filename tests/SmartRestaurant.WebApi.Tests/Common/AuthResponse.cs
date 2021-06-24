using System.Collections.Generic;

namespace SmartRestaurant.WebApi.Tests.Common
{
    public class AuthResponse
    {
        public string token { get; set; }
        public string userName { get; set; }
        public List<string> roles { get; set; }
    }
}