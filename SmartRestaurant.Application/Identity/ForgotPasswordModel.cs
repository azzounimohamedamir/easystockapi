using SmartRestaurant.Application.Identity.Interfaces;

namespace SmartRestaurant.Application.Identity
{
    public class ForgotPasswordModel : IForgotPasswordModel
    {
        public string Email { get; set; }
    }
}
