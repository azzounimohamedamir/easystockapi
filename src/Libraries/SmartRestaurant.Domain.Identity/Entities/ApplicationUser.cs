using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

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
			IsShowPhoneNumberInOdoo=false;
		}

		public ApplicationUser()
		{
			IsActive = true;
			IsShowPhoneNumberInOdoo=false;
		}

		public string FullName { get; set; }
		public bool IsActive { get; set; }
		public bool? IsShowPhoneNumberInOdoo { get; set; }
		

		public ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
	}
}