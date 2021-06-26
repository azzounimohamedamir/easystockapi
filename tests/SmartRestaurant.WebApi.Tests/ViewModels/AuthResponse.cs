using System.Collections.Generic;

namespace SmartRestaurant.WebApi.Tests.Common
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}