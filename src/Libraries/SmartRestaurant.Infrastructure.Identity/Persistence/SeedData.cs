using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                    Id = Guid.NewGuid().ToString(),
                    Name = "SuperAdmin",
                    NormalizedName = Roles.SuperAdmin.ToString().ToUpper(),
                    ConcurrencyStamp = "88f0dec2-5364-4881-9817-1f2a135a8649"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = Roles.Admin.ToString().ToUpper(),
                    ConcurrencyStamp = "5719c2b8-22fd-4eee-9c21-4bfbd2ce18d7"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = Roles.User.ToString().ToUpper(),
                    ConcurrencyStamp = "eccc7115-422c-487d-95b0-58cfa8e66a94"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "RestaurantAdministrator",
                    NormalizedName = Roles.User.ToString().ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );
        }
    }
}
