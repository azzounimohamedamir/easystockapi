using System;
using System.Threading.Tasks;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class RolesTestTools
    {
        public static async Task<Domain.Entities.FoodBusiness> CreateFoodBusiness()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test",
                DefaultCurrency = Currencies.USD
            };
            await SendAsync(createFoodBusinessCommand);
            var fastFood = await FindAsync<Domain.Entities.FoodBusiness>(createFoodBusinessCommand.Id);
            return fastFood;
        }

        public static async Task CreateRoles()
        {
            await CreateSuperAdminRole();
            await CreateSupportAgentRole();
            await CreateSalesManRole();
            await CreatePhotographRole();
            await CreateFoodBusinessAdministratorRole();
            await CreateFoodBusinessManagerRole();
            await CreateFoodBusinessOwnerRole();
            await CreateChefRole();
            await CreateCashierRole();
            await CreateWaiterRole();
            await CreateDinerRole();
            await CreateAnounymousRole();
            await CreateOrganizationRole();
            await CreateHotelReceptionnisteRole();
            await CreateHotelServiceAdminRole();

        }

        private static async Task CreateSuperAdminRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.SuperAdmin).ToString(),
                Name = Roles.SuperAdmin.ToString(),
                NormalizedName = Roles.SuperAdmin.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateSupportAgentRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.SupportAgent).ToString(),
                Name = Roles.SupportAgent.ToString(),
                NormalizedName = Roles.SupportAgent.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateSalesManRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.SalesMan).ToString(),
                Name = Roles.SalesMan.ToString(),
                NormalizedName = Roles.SalesMan.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreatePhotographRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.Photograph).ToString(),
                Name = Roles.Photograph.ToString(),
                NormalizedName = Roles.Photograph.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }




        private static async Task CreateHotelReceptionnisteRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int)Roles.HotelReceptionist).ToString(),
                Name = Roles.HotelReceptionist.ToString(),
                NormalizedName = Roles.HotelReceptionist.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateHotelServiceAdminRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int)Roles.HotelServiceAdmin).ToString(),
                Name = Roles.HotelServiceAdmin.ToString(),
                NormalizedName = Roles.HotelServiceAdmin.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }


        private static async Task CreateFoodBusinessAdministratorRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.FoodBusinessAdministrator).ToString(),
                Name = Roles.FoodBusinessAdministrator.ToString(),
                NormalizedName = Roles.FoodBusinessAdministrator.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateFoodBusinessManagerRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.FoodBusinessManager).ToString(),
                Name = Roles.FoodBusinessManager.ToString(),
                NormalizedName = Roles.FoodBusinessManager.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateFoodBusinessOwnerRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.FoodBusinessOwner).ToString(),
                Name = Roles.FoodBusinessOwner.ToString(),
                NormalizedName = Roles.FoodBusinessOwner.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateChefRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.Chef).ToString(),
                Name = Roles.Chef.ToString(),
                NormalizedName = Roles.Chef.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateCashierRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.Cashier).ToString(),
                Name = Roles.Cashier.ToString(),
                NormalizedName = Roles.Cashier.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateWaiterRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.Waiter).ToString(),
                Name = Roles.Waiter.ToString(),
                NormalizedName = Roles.Waiter.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateDinerRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.Diner).ToString(),
                Name = Roles.Diner.ToString(),
                NormalizedName = Roles.Diner.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateAnounymousRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.Anounymous).ToString(),
                Name = Roles.Anounymous.ToString(),
                NormalizedName = Roles.Anounymous.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }

        private static async Task CreateOrganizationRole()
        {
            var roles = new ApplicationRole
            {
                Id = ((int) Roles.Organization).ToString(),
                Name = Roles.Organization.ToString(),
                NormalizedName = Roles.Organization.ToString().ToUpper()
            };
            await AddIdentityAsync(roles);
        }
    }
}