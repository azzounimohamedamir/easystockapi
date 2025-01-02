using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Queries
{
    using static Testing;

    public class GetFoodBusinessByIdTests : TestBase
    {
        [Test]
        public async Task ShouldReturnFoodBusiness()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            
            var createVipZone = await CreateVipZone(fastFood);
            await CreateTables(createVipZone.Id.ToString());

            var createFamilyZone = await CreateFamilyZone(fastFood);
            await CreateTables(createFamilyZone.Id.ToString());
            await CreateTables(createFamilyZone.Id.ToString());

            await CreateMenu(fastFood.FoodBusinessId);

            var query = new GetFoodBusinessByIdQuery
            {
                FoodBusinessId = fastFood.FoodBusinessId
            };
            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.zonesCount.Should().Be(2);
            result.menusCount.Should().Be(1);
            result.tablesCount.Should().Be(3);
        }

        private static async Task<CreateZoneCommand> CreateFamilyZone(Domain.Entities.FoodBusiness fastFood)
        {
           return  await ZoneTestTools.CreateZone(fastFood, "Family Zone",true);
        }

        private static async Task<CreateZoneCommand> CreateVipZone(Domain.Entities.FoodBusiness fastFood)
        {
            return await ZoneTestTools.CreateZone(fastFood, "VIP Zone",true);
        }

        private static async Task CreateMenu(Guid foodBusinessId)
        {
            await SendAsync(new CreateProductOnStockCommand
            {
                FoodBusinessId = foodBusinessId,
                Name = "Pizza Zone"
            });
        }

        private static async Task CreateTables(string zoneId)
        {
            await SendAsync(new CreateTableCommand
            {
                ZoneId = zoneId,
                Capacity = 4
            });
        }
    }
}