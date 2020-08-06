using System.ComponentModel.DataAnnotations;

namespace SmartRestaurant.API.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}