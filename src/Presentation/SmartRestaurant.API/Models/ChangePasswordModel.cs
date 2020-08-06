using System.ComponentModel.DataAnnotations;

namespace SmartRestaurant.API.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}
