using System;

namespace SmartRestaurant.Forms.Services
{
    public class JwtToken
    {
        public string token { get; set; }
        public DateTime experation { get; set; }
    }
}