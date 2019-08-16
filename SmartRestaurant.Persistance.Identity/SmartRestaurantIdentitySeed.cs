using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Domain.BaseIdentity;
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
            },
            {
                "RST02",
                "12689539-7dfc-4916-9ac0-692f50bb03c3".ToGuid()
            },
            {
                "RST03",
                "ada8720c-52e4-472d-b92c-252ba638db2f".ToGuid()
            }
        };
        private readonly Dictionary<string, Guid> chainsIds = new Dictionary<string, Guid>
        {
            {
                "OWN01",
                "a6e6b3ab-8f73-4af2-a7c0-b6d5d6e22372".ToGuid()

            },
            {
                "OWN02",
                "0338643f-87c8-4415-bd14-256020fcf34e".ToGuid()
            },
            {
                "OWN03",
                "0c703c18-4d7f-4586-b1d6-d02a60df9b09".ToGuid()
            }
        };

        public SmartRestaurantIdentitySeed(SmartRestaurantIdentityDbContext context)
        {
            this.context = context;
        }


        public async Task CreateRoles(IServiceProvider serviceProvider )
        {
            /// Seeding a custom Roles 

            //var UserManager = serviceProvider.GetRequiredService<UserManager<BaseIdentityUser>>();
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<SRIdentityRole>>();
            string[] roleNames = Enum.GetNames(typeof(EnumPersoneType));

         

            foreach (var roleName in roleNames)
            {
                try
                {
                    var roleExist = await RoleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        //create the roles and seed them to the database !!
                        await RoleManager.CreateAsync(new SRIdentityRole(roleName));

          }
                }
                catch (Exception e)
                {

                    throw;
                }
               
                
            }

           // var poweruser = new BaseIdentityUser
           // {
           //  UserName = Configuration.GetSection("UserSettings")["UserEmail"],
           // Email = Configuration.GetSection("UserSettings")["UserEmail"]  };​
         
           // string UserPassword = Configuration.GetSection("UserSettings")["UserPassword"];
           // var _user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);        ​
           //  if (_user == null)
           // {
           //     var createPowerUser = await UserManager.CreateAsync(poweruser, UserPassword);
           //     if (createPowerUser.Succeeded)
           //     {
           //         //here we tie the new user to the "Admin" role 
           //await UserManager.AddToRoleAsync(poweruser, "Admin");
           // ​
           //                     }
           // }




        }
        public async Task CreateDummyUser(IServiceProvider serviceProvider)
        {
           
            var UserManager = serviceProvider.GetRequiredService<
                UserManager<BaseIdentityUser>>();

            var StaffManager = serviceProvider.GetRequiredService<
                UserManager<SRIdentityUser>>();
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<BaseIdentityRole>>();

            var roleExist = await RoleManager.RoleExistsAsync("Developer");
            if (!roleExist)
            {
                //create the roles and seed them to the database !!
                await RoleManager.CreateAsync(new BaseIdentityRole("Developer"));

            }

            // adding developpers 
            await CreateUserToRole(UserManager,
                "Ahmed", "Ahmed", "Djaalab", "hhhh@com");
            await CreateUserToRole(UserManager,
                "Okba", "Okba", "Kadi", "hhhh@com");
            await CreateUserToRole(UserManager,
                "Ghassan", "Ghassan", "Hadj Ahmed", "hhhh@com");
            /// adding restuanrtes Staff 
            /// fetch restaurantes ID

            string[] roleNames = Enum.GetNames(typeof(EnumPersoneType));
            var count = 0;
            ///TODO: verifying Chains ids 
          

          foreach (var restaurantId in restaurantsIds)
            {
                   
                foreach (var rolename in roleNames)
                {

                    await CreateStaffToRole(StaffManager,
                                      rolename + restaurantId.Key.ToString()
                                      , rolename + restaurantId.Key.ToString(),
                                      rolename + restaurantId.Key.ToString(),
                                      rolename + restaurantId.Value.ToString() + "@" + "com",
                                      rolename,
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
        public async Task CreateUserToRole(UserManager<BaseIdentityUser> userManager,
            string username, string firstname, string lastname, string email)
        {


            string pass = "A*a123456789";
            var user = new BaseIdentityUser()
            {
                UserName = username,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
            };

            try
            {
                var result = await userManager.CreateAsync(user, pass);
                if (result.Succeeded)
                {
                    var currentUser = await userManager.FindByNameAsync(user.UserName);

                    var roleresult = await userManager.AddToRoleAsync(currentUser, "Developer");

                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async Task CreateStaffToRole(UserManager<SRIdentityUser> userManager
            , string username,
            string firstname,
            string lastname,
            string email,
            string RoleName,
            string restuarantId,
            string ChainId
            )
        {
            string pass = "A*a123456789";
            var user = new SRIdentityUser()
            {
                UserName = username,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                RestaurantId = restuarantId,
                ChainId = ChainId,
                IsDisabled = true ,
                
            };
          
            var identityResult = await userManager.CreateAsync(user, pass);
            if (identityResult.Succeeded)
            {
                await userManager.AddClaimAsync(user, new Claim("organisation", "g22r"));
                await userManager.AddClaimAsync(user, new Claim("unique_name", user.UserName));
                await userManager.AddClaimAsync(user, new Claim("RestuarantId", user.RestaurantId));
                if (RoleName == "Owner")
                {
                    await userManager.AddClaimAsync(user, new Claim("ChainId", ChainId));
                }
                await userManager.AddToRoleAsync(user, RoleName);
                
                await userManager.AddClaimAsync(user, new Claim("family_name", user.FirstName));
                await userManager.AddClaimAsync(user, new Claim("last_name", user.LastName));
                await userManager.AddClaimAsync(user, new Claim("gender", "1"));
                await userManager.AddClaimAsync(user, new Claim("email", user.Email));
                await userManager.AddClaimAsync(user, new Claim("id", user.Id));
                ///TODO: isdisabled
                await userManager.AddClaimAsync(user, new Claim("isdisabled", user.IsDisabled.ToString()));


            }

        }
        #endregion
    }
}
