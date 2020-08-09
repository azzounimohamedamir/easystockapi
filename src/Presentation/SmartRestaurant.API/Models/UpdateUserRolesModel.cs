using System.Collections.Generic;

namespace SmartRestaurant.API.Models
{
    public class UpdateUserRolesModel
    {
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}
