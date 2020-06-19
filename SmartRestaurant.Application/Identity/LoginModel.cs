using SmartRestaurant.Application.Identity.Interfaces;

namespace SmartRestaurant.Application.Identity
{
    public class LoginModel : ILoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}
