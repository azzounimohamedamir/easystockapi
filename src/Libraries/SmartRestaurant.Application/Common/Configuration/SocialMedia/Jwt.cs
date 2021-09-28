namespace SmartRestaurant.Application.Common.Configuration.SocialMedia
{
    public class Jwt
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public int JwtExpireDays { get; set; }
    }
}
