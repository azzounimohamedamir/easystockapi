using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
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
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);


            var createZoneCommand = new CreateZoneCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "VIP Zone"
            };

            await SendAsync(createZoneCommand);

            await CreateTables(createZoneCommand.Id);

            await CreateMenu(fastFood.FoodBusinessId);

            var query = new GetFoodBusinessByIdQuery
            {
                FoodBusinessId = fastFood.FoodBusinessId
            };

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.zonesCount.Should().Be(1);
            result.menusCount.Should().Be(1);
            result.tablesCount.Should().Be(3);
        }

        private static async Task CreateMenu(Guid foodBusinessId)
        {
            await SendAsync(new CreateMenuCommand
            {
                FoodBusinessId = foodBusinessId,
                Name = "Pizza Zone"
            });
        }

        private static async Task CreateTables(Guid zoneId)
        {
            await SendAsync(new CreateTableCommand
            {
                ZoneId = zoneId,
                TableNumber = 3,
                Capacity = 4
            });
        }
    }
}