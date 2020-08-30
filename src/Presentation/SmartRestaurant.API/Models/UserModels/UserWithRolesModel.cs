using Newtonsoft.Json;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.API.Models.UserModels
{
    public class UserWithRolesModel
    {
        public UserWithRolesModel(ApplicationUser user , string [] roles)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            UserName = user.UserName;
            Roles= string.Join(",", roles);
            
        }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }
        public string PhoneNumber { get; set; }
    }
}
