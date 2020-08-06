using System.ComponentModel.DataAnnotations;

namespace SmartRestaurant.API.Models
{
    public class ApplicationUserModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
