using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Persistance.Identity
{
    public class SmartRestaurantIdentitySeed
    {
        private readonly SmartRestaurantIdentityDbContext context;
        private readonly Dictionary<string, Guid> restaurantsIds = new Dictionary<string, Guid>
        {
            {
                "RST01",
                "27e7e25a-cf92-4ea5-a9cc-b77d4d220efc".ToGuid()
            }
            
        };
        private readonly Dictionary<string, Guid> chainsIds = new Dictionary<string, Guid>
        {
            {
                "OWN01",
                "a6e6b3ab-8f73-4af2-a7c0-b6d5d6e22372".ToGuid()

            }
        };

        public SmartRestaurantIdentitySeed(SmartRestaurantIdentityDbContext context)
        {
            this.context = context;
        }

        /// Seeding a custom Roles 
        public async Task CreateRoles(IServiceProvider serviceProvider)
        {
           
            var roleManager = serviceProvider.GetRequiredService<RoleManager<SRIdentityRole>>();
            string[] roleNames = Enum.GetNames(typeof(EnumPersoneType));

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                    //create the roles and seed them to the database !!
                    await roleManager.CreateAsync(new SRIdentityRole(roleName));
            }
        }

        public async Task CreateDummyUser(IServiceProvider serviceProvider)
        {

            var userManager = serviceProvider.GetRequiredService<UserManager<SRIdentityUser>>();
            var staffManager = serviceProvider.GetRequiredService<UserManager<SRIdentityUser>>();
           // adding admin account
            await CreateUserToRole(userManager, "admin", "admin", "Administrator", "adminn@sr.com");
            string[] roleNames = Enum.GetNames(typeof(EnumPersoneType));
            var count = 0;
        
            foreach (var restaurantId in restaurantsIds)
            {

                foreach (var roleName in roleNames.Where(r=>  r.Equals("Owner")))
                {

                    await CreateStaffToRole(staffManager,
                        roleName + restaurantId.Key.ToString()
                        ,roleName + restaurantId.Key.ToString(),
                        roleName + restaurantId.Key.ToString(),
                        roleName + restaurantId.Value.ToString() + "@" + "com",
                        roleName,
                        restaurantId.Value.ToString(),
                        chainsIds.ElementAt(count).Value.ToString()

                    );
                }

                count++;

            }
        }


        #region Helper Methodes

        /// <summary>
        /// Creating developpe team user and roles 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="username"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task CreateUserToRole(UserManager<SRIdentityUser> userManager,string username, string firstname, string lastname, string email)
        {

            string pass = "Abcd$001";
            var user = new SRIdentityUser
            {
                UserName = username,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
            };

            var result = await userManager.CreateAsync(user, pass);
            if (result.Succeeded)
            {
                var currentUser = await userManager.FindByNameAsync(user.UserName);
                await userManager.AddToRoleAsync(currentUser, "Admin");
            }

        }
        public async Task CreateStaffToRole(UserManager<SRIdentityUser> userManager, string username, string firstname, string lastname, string email, string RoleName, string restuarantId, string ChainId)
        {
            string pass = "A*a123456789";
            var user = new SRIdentityUser
            {
                UserName = username,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                RestaurantId = restuarantId,
                ChainId = ChainId,
                IsDisabled = true ,
                
            };
          
            await userManager.CreateAsync(user, pass);
            await userManager.AddToRoleAsync(user, RoleName);
            

        }
        #endregion
    }
}
