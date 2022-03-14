using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using FluentAssertions;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Tables.Commands;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateStatusOrderTest : TestBase
    {                   
        [Test]
        public async Task UpdateStatusOrder_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createZoneCommand = await CreateZone(fastFood);
            await CreateTable(createZoneCommand);

            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null);
            var createdOrder = await GetOrder(createOrderCommand.Id);
            createdOrder.Status.Should().Be(OrderStatuses.InQueue);

            var updateOrderCommand = await UpdateOrderStatus(createOrderCommand);
            var updatedOrderStatus = await GetOrder(Guid.Parse(updateOrderCommand.Id));
            updatedOrderStatus.Status.Should().Be(OrderStatuses.Cancelled);   
        }


        private async Task<UpdateOrderStatusCommand> UpdateOrderStatus(CreateOrderCommand createOrderCommand)
        {
            var updateStatusOrderCommand = new UpdateOrderStatusCommand
            {
               Id = createOrderCommand.Id.ToString(),
               Status = OrderStatuses.Cancelled
            };
            await SendAsync(updateStatusOrderCommand);
            return updateStatusOrderCommand;
        }

        private static async Task CreateTable(CreateZoneCommand createZoneCommand)
        {
            var createTableCommand01 = new CreateTableCommand
            {
                Id = Guid.Parse("44aecd78-59bb-7504-bfff-07c07129ab00"),
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