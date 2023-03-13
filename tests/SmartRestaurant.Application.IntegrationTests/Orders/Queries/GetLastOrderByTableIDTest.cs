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
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            var selectedTabelId = "44aecd78-59bb-7504-bfff-07c07129ab00";
            await CreateTable(createZoneCommand, selectedTabelId);
            
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);
            
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);
            
            await OrderTestTools.UpdateOrderStatus(createOrderCommand);
            
            var createOrderCommand2 = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);
            
            var lastOrder = await SendAsync(new GetLastOrderByTableIDQuery { TableId = selectedTabelId });
            lastOrder.Should().NotBeNull();
            Assert.AreEqual(lastOrder.OrderId, createOrderCommand2.Id.ToString());
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
    }
}
