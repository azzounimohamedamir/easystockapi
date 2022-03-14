using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Orders.Queries;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Queries
{
     using static Testing;

    [TestFixture]
    public class GetLastOrderByTableIDTest : TestBase
    {
        [Test]
        public async Task GetLastOrderByTableIDQuery_ShouldReturnTheLastOrderInTheSelectedTable()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createZoneCommand = await CreateZone(fastFood);
            var selectedTabelId = "44aecd78-59bb-7504-bfff-07c07129ab00";
            await CreateTable(createZoneCommand, selectedTabelId);
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null);
            var order = await GetOrder(createOrderCommand.Id);
            var lastOrder = await SendAsync(new GetLastOrderByTableIDQuery { TableId = selectedTabelId });
            lastOrder.Should().NotBeNull();
            Assert.AreEqual(lastOrder.OrderId, order.OrderId);
        }

        private static async Task CreateTable(CreateZoneCommand createZoneCommand, string idTable)
        {
            var createTableCommand01 = new CreateTableCommand
            {
                Id = Guid.Parse(idTable),
                Capacity = 4,
                ZoneId = createZoneCommand.Id.ToString()
            };
            await SendAsync(createTableCommand01);
        }

        private static async Task<CreateZoneCommand> CreateZone(Domain.Entities.FoodBusiness fastFood)
        {
            var createZoneCommand = new CreateZoneCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "zone 45"
            };
            await SendAsync(createZoneCommand);
            return createZoneCommand;
        }
    }
}
