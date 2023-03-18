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
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await TablesTestTools.CreateTable(createZoneCommand);

            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);

            var createdOrder = await GetOrder(createOrderCommand.Id);
            createdOrder.Status.Should().Be(OrderStatuses.InQueue);

            var updateOrderCommand = await OrderTestTools.UpdateOrderStatus(createOrderCommand);

            var updatedOrderStatus = await GetOrder(Guid.Parse(updateOrderCommand.Id));
            updatedOrderStatus.Status.Should().Be(OrderStatuses.Cancelled);   
        }



      
    }
}