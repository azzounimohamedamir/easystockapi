using System.ComponentModel.DataAnnotations;

namespace SmartRestaurant.API.Models
{
    public class RegisterSocialMediaModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
