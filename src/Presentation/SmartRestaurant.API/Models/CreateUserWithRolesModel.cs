using System.Collections.Generic;

namespace SmartRestaurant.API.Models
{
    public class CreateUserWithRolesModel
    {
        public ApplicationUserModel User { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
