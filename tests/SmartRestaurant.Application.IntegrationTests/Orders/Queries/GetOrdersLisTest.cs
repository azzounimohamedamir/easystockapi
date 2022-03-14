using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Dishes.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Orders.Queries;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Queries
{
    using static Testing;

    [TestFixture]
    public class GetOrdersLisTest : TestBase
    {   
        [Test]
        public async Task GetOrdersList()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createZoneCommand = await CreateZone(fastFood);
            await CreateTable(createZoneCommand);
            await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null);


            var dishesList_01 = await SendAsync(new GetOrdersListQuery { FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            dishesList_01.Data.Should().HaveCount(1);

            var dishesList_02 = await SendAsync(new GetOrdersListQuery { CurrentFilter = "number", SearchKey = "0001" , FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            dishesList_02.Data.Should().HaveCount(1);

            var dishesList_03 = await SendAsync(new GetOrdersListQuery { CurrentFilter = "number", SearchKey = "0002", FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            dishesList_03.Data.Should().HaveCount(0);

            var dishesList_04 = await SendAsync(new GetOrdersListQuery { CurrentFilter = "number", DateInterval = DateFilter.ToDay, FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            dishesList_04.Data.Should().HaveCount(1);

            var dishesList_05 = await SendAsync(new GetOrdersListQuery { CurrentFilter = "number", SearchKey = "test", FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            dishesList_05.Data.Should().HaveCount(0);
        }

        private static async Task CreateTable(CreateZoneCommand createZoneCommand)
        {
            var createTableCommand = new CreateTableCommand
            {
                Id = Guid.Parse("44aecd78-59bb-7504-bfff-07c07129ab00"),
                Capacity = 4,
                ZoneId = createZoneCommand.Id.ToString()
            };
            await SendAsync(createTableCommand);
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
