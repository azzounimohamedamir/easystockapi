using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Infrastructure.Identity.Enums;
using SmartRestaurant.Infrastructure.Identity.Persistence;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/seed")]
    [ApiController]
    public class SeedController : ApiController
    {
        private readonly IdentityContext _identityDbContext;

        public SeedController(IdentityContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        [HttpGet]
        public IActionResult Seed()
        {
            try
            {
                _identityDbContext.Users.AddRange(new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        Id = "3cbf3570-0d44-4673-8746-29b7cf568093",
                        UserName = "SuperAdmin@SmartRestaurant.io",
                        Email = "SuperAdmin@SmartRestaurant.io",
                        NormalizedUserName = "SUPERADMIN@SMARTRESTAURANT.IO",
                        NormalizedEmail = "SUPERADMIN@SMARTRESTAURANT.IO",
                        PasswordHash =
                            "AQAAAAEAACcQAAAAEAzFpmzMtMiw0wHV6b0aUzFLF9Pw7B2u+DswRHttAU2nH22NHBsc/hSSvKUqmRWGZA==",
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        Id = "d466ef00-61f1-4e77-801a-b016f0f12323",
                        UserName = "SupportAgent@SmartRestaurant.io",
                        Email = "SupportAgent@SmartRestaurant.io",
                        NormalizedUserName = "SUPPORTAGENT@SMARTRESTAURANT.IO",
                        NormalizedEmail = "SUPPORTAGENT@SMARTRESTAURANT.IO",
                        PasswordHash =
                            "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==",
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        Id = "d466ef00-61f1-4e77-801a-b516f0f12323",
                        UserName = "Waiter@SmartRestaurant.io",
                        Email = "Waiter@SmartRestaurant.io",
                        NormalizedUserName = "WAITER@SMARTRESTAURANT.IO",
                        NormalizedEmail = "WAITER@SMARTRESTAURANT.IO",
                        PasswordHash =
                            "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==",
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        Id = "3cbf3570-4444-4444-8746-29b7cf568093",
                        UserName = "FoodAdmin@SmartRestaurant.io",
                        Email = "FoodAdmin@SmartRestaurant.io",
                        NormalizedUserName = "FOODADMIN@SMARTRESTAURANT.IO",
                        NormalizedEmail = "FOODADMIN@SMARTRESTAURANT.IO",
                        PasswordHash =
                            "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==",
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        Id = "a1997466-cedc-4850-b18d-0ac4f4102cff",
                        UserName = "FoodBusinessManager@SmartRestaurant.io",
                        Email = "FoodBusinessManager@SmartRestaurant.io",
                        NormalizedUserName = "FOODBUSINESSMANAGER@SMARTRESTAURANT.IO",
                        NormalizedEmail = "FOODBUSINESSMANAGER@SMARTRESTAURANT.IO",
                        // Real password is "FoodBusinessManager123@"
                        PasswordHash =
                            "AQAAAAEAACcQAAAAEGsuHVzJHLS9jP+mo+zCHk22BZphE5WRR+o2C6Ct4Ektv8zW9DXj1nogD2OdNBjWPA==",
                        EmailConfirmed = true
                    }
                });
                
                _identityDbContext.UserRoles.AddRange(new List<IdentityUserRole<string>>
                {
                    new IdentityUserRole<string>
                    {
                        UserId = "3cbf3570-0d44-4673-8746-29b7cf568093",
                        RoleId = "1"
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = "d466ef00-61f1-4e77-801a-b016f0f12323",
                        RoleId = "2"
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = "d466ef00-61f1-4e77-801a-b516f0f12323",
                        RoleId = "10"
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = "3cbf3570-4444-4444-8746-29b7cf568093",
                        RoleId = "5"
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = "a1997466-cedc-4850-b18d-0ac4f4102cff",
                        RoleId = "6"
                    }
                });

                _identityDbContext.SaveChanges();
            }
            catch
            {
                return Ok("Done with errors");
            }

            return Ok("Done");
        }
    }
}