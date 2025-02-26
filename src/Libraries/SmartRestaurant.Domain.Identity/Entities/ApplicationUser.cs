using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Identity.Entities
{
    public sealed class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string fullName, string email, string userName)
        {
            FullName = fullName;
            UserName = userName;
            Email = email;
            IsActive = true;
            IsShowPhoneNumberInOdoo = false;
        }

        public ApplicationUser()
        {
            IsActive = true;
            IsShowPhoneNumberInOdoo = false;
        }

        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public bool? IsShowPhoneNumberInOdoo { get; set; }
#pragma warning disable CS8632 // L'annotation pour les types référence Nullable doit être utilisée uniquement dans le code au sein d'un contexte d'annotations '#nullable'.
        public string? Mac { get; set; }
#pragma warning restore CS8632 // L'annotation pour les types référence Nullable doit être utilisée uniquement dans le code au sein d'un contexte d'annotations '#nullable'.


        public ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}