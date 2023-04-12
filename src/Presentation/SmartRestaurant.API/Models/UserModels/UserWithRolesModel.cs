using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.API.Models.UserModels
{
    public class UserWithRolesModel
    {
        public UserWithRolesModel(ApplicationUser user, IEnumerable<string> roles)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            UserName = user.UserName;
            Roles = roles.ToList();
            IsShowPhoneNumberInOdoo = user.IsShowPhoneNumberInOdoo;
        }

        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsShowPhoneNumberInOdoo { get; set; }
    }
}