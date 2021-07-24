using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
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
            var foodBusinessId = Guid.NewGuid();
            await CreateFoodBusiness(foodBusinessId);

            var zoneId = Guid.NewGuid();
            await CreateZone(foodBusinessId, zoneId);

            await CreateTables(zoneId);

            await CreateMenu(foodBusinessId);

            var query = new GetFoodBusinessByIdQuery
            {
                FoodBusinessId = foodBusinessId
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

        private static async Task CreateZone(Guid foodBusinessId, Guid zoneId)
        {
            await SendAsync(new CreateZoneCommand
            {
                FoodBusinessId = foodBusinessId,
                ZoneTitle = "VIP Zone",
                CmdId = zoneId
            });
        }

        private static async Task CreateFoodBusiness(Guid foodBusinessId)
        {
            await SendAsync(new CreateFoodBusinessCommand
            {
                Name = "TobeGotByID For Test",
                AverageRating = 12,
                HasCarParking = true,
                CmdId = foodBusinessId,
                FoodBusinessAdministratorId = Guid.NewGuid().ToString()
            });
        }
    }
}