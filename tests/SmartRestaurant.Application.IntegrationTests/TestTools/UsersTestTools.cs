using System;
using System.Threading.Tasks;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class UsersTestTools
    {
        public static async Task<ApplicationUser> CreateFoodBusinessAdministrator()
        {
            var user = new ApplicationUser()
            {
                FullName = "FoodBusinessAdministrator",
                Email = "FoodBusinessAdministrator@bv.com",
                UserName = "FoodBusinessAdministrator@bv.com",
                PhoneNumber = "077654656",
                IsActive = true,
                EmailConfirmed = true,
                // Real password is "Supportagent123@"
                PasswordHash = "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw=="
            };
            await AddIdentityAsync(user);

            var userRole1 = new ApplicationUserRole()
            {
                UserId = user.Id,
                RoleId = Convert.ToString((int)Roles.FoodBusinessAdministrator)
            };
            await AddIdentityAsync(userRole1);

            return user;
        }

        public static async Task<ApplicationUser> CreateFoodBusinessAdministrator(string userId)
        {
            var user = new ApplicationUser()
            {
                Id = userId,
                FullName = "FoodBusinessAdministrator",
                Email = "FoodBusinessAdministrator@bv.com",
                UserName = "FoodBusinessAdministrator@bv.com",
                PhoneNumber = "077654656",
                IsActive = true,
                EmailConfirmed = true,
                // Real password is "Supportagent123@"
                PasswordHash = "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw=="
            };
            await AddIdentityAsync(user);

            var userRole1 = new ApplicationUserRole()
            {
                UserId = userId,
                RoleId = Convert.ToString((int)Roles.FoodBusinessAdministrator)
            };
            await AddIdentityAsync(userRole1);

            return user;
        }

        public static async Task<ApplicationUser> CreateFoodBusinessClientManager()
        {
            var user = new ApplicationUser()
            {
                FullName = "FoodBusinessClientManager",
                Email = "FoodBusinessClientManager@bv.com",
                UserName = "FoodBusinessClientManager@bv.com",
                PhoneNumber = "077654656",
                IsActive = true,
                EmailConfirmed = true,
                // Real password is "Supportagent123@"
                PasswordHash = "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw=="
            };
            await AddIdentityAsync(user);

            var userRole1 = new ApplicationUserRole()
            {
                UserId = user.Id,
                RoleId = Convert.ToString((int)Roles.Organization)
            };
            await AddIdentityAsync(userRole1);

            return user;
        }

        public static async Task<ApplicationUser> CreateClient(string userId)
        {
            var user = new ApplicationUser()
            {
                Id = userId,
                FullName = "Client",
                Email = "ClientHotel@gmail.com",
                UserName = "ClientHotel@bv.com",
                PhoneNumber = "0561279578",
                IsActive = true,
                EmailConfirmed = true,
                // Real password is "Supportagent123@"
                PasswordHash = "AQAAAAEAACcQAAAAEE2YnCbwcY+aBvcZq2dTXfaPqZnSgNoXFKtyI0hIdVJI3tTBvln+3oc+p1Ijr/ckMw=="
            };
            await AddIdentityAsync(user);

            var userRole1 = new ApplicationUserRole()
            {
                UserId = user.Id,
                RoleId = Convert.ToString((int)Roles.HotelClient)
            };
            await AddIdentityAsync(userRole1);

            return user;
        }

    }
}