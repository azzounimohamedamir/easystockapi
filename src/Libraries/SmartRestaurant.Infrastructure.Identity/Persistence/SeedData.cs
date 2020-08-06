using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Infrastructure.Identity.Enums;

namespace SmartRestaurant.Infrastructure.Identity.Persistence
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ((long)Roles.SuperAdmin).ToString(),
                    Name = Roles.SuperAdmin.ToString(),
                    NormalizedName = Roles.SuperAdmin.ToString().ToUpper(),
                    ConcurrencyStamp = "88f0dec2-5364-4881-4817-1f2a135a8641"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.SupportAgent).ToString(),
                    Name = Roles.SupportAgent.ToString(),
                    NormalizedName = Roles.SupportAgent.ToString().ToUpper(),
                    ConcurrencyStamp = "emec7115-422c-487d-65b0-58cfa8e66a94"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.SalesMan).ToString(),
                    Name = Roles.SalesMan.ToString(),
                    NormalizedName = Roles.SalesMan.ToString().ToUpper(),
                    ConcurrencyStamp = "emrc7115-422c-487d-75b0-58cfa8e66a94"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.Photograph).ToString(),
                    Name = Roles.Photograph.ToString(),
                    NormalizedName = Roles.Photograph.ToString().ToUpper(),
                    ConcurrencyStamp = "emtc7115-422c-487d-85b0-58cfa8e66a94"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.FoodBusinessAdministrator).ToString(),
                    Name = Roles.FoodBusinessAdministrator.ToString(),
                    NormalizedName = Roles.FoodBusinessAdministrator.ToString().ToUpper(),
                    ConcurrencyStamp = "5719c2b8-22fd-4eee-9c21-4bfbd2ce18d2"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.FoodBusinessManager).ToString(),
                    Name = Roles.FoodBusinessManager.ToString(),
                    NormalizedName = Roles.FoodBusinessManager.ToString().ToUpper(),
                    ConcurrencyStamp = "emcc7115-422c-487d-95b0-58cfa8e66a94"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.FoodBusinessOwner).ToString(),
                    Name = Roles.FoodBusinessOwner.ToString(),
                    NormalizedName = Roles.FoodBusinessOwner.ToString().ToUpper(),
                    ConcurrencyStamp = "emcb7115-422c-487d-95c0-58cfa8m66a94"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.Cashier).ToString(),
                    Name = Roles.Cashier.ToString(),
                    NormalizedName = Roles.Cashier.ToString().ToUpper(),
                    ConcurrencyStamp = "encc7115-422c-487d-95b0-58cfa8e66a95"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.Chef).ToString(),
                    Name = Roles.Chef.ToString(),
                    NormalizedName = Roles.Chef.ToString().ToUpper(),
                    ConcurrencyStamp = "elcc7115-422c-487d-95b0-58cfa8e66a96"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.Waiter).ToString(),
                    Name = Roles.Waiter.ToString(),
                    NormalizedName = Roles.Waiter.ToString().ToUpper(),
                    ConcurrencyStamp = "ekcc7115-422c-487d-95b0-58cfa8e66a97"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.Diner).ToString(),
                    Name = Roles.Diner.ToString(),
                    NormalizedName = Roles.Diner.ToString().ToUpper(),
                    ConcurrencyStamp = "edcc7115-422c-487d-95b0-58cfa8e66a98"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.Anounymous).ToString(),
                    Name = Roles.Anounymous.ToString(),
                    NormalizedName = Roles.Anounymous.ToString().ToUpper(),
                    ConcurrencyStamp = "educ7115-422c-487d-25b0-58cfa8e66a98"
                },
                new IdentityRole
                {
                    Id = ((long)Roles.Organization).ToString(),
                    Name = Roles.Organization.ToString(),
                    NormalizedName = Roles.Organization.ToString().ToUpper(),
                    ConcurrencyStamp = "edpc7115-422c-487d-15b0-58cfa8e66a98"
                }
            );
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Id = "3cbf3570-0d44-4673-8746-29b7cf568093",
                    UserName = "SuperAdmin@SmartRestaurant.io",
                    Email = "SuperAdmin@SmartRestaurant.io",
                    NormalizedUserName = "SUPERADMIN@SMARTRESTAURANT.IO",
                    NormalizedEmail = "SUPERADMIN@SMARTRESTAURANT.IO",
                    PasswordHash = "AQAAAAEAACcQAAAAEAzFpmzMtMiw0wHV6b0aUzFLF9Pw7B2u+DswRHttAU2nH22NHBsc/hSSvKUqmRWGZA==",
                    EmailConfirmed = true
                },
                new ApplicationUser()
                {
                    Id = "d466ef00-61f1-4e77-801a-b016f0f12323",
                    UserName = "SupportAgent@SmartRestaurant.io",
                    Email = "SupportAgent@SmartRestaurant.io",
                    NormalizedUserName = "SSUPERADMIN@SMARTRESTAURANT.IO",
                    NormalizedEmail = "SUPERADMIN@SMARTRESTAURANT.IO",
                    PasswordHash = "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw==",
                    EmailConfirmed = true
                }
             );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "3cbf3570-0d44-4673-8746-29b7cf568093",
                    RoleId = "1"
                },
                new IdentityUserRole<string>
                {
                    UserId = "d466ef00-61f1-4e77-801a-b016f0f12323",
                    RoleId = "2"
                }
           );
        }
    }
}