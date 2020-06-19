using System.ComponentModel.DataAnnotations;

namespace SmartRestaurant.Client.Web.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
