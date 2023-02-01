using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using FluentAssertions;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Tables.Commands;
using Newtonsoft.Json;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateOrderDeliveryOutWorkTimeTest : TestBase
    {
        [Test]
        public async Task CreateOrderDeliveryOutWorkTimeShould_be_rejected()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct();
            DateTime orderTime = new DateTime(2008, 3, 9, 8, 5, 7, 123); 
            ConfigureDateTimeNow(orderTime);
            var createOrderCommand = await OrderTestTools.CreateOrderDelivery(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);
            var order = await GetOrder(createOrderCommand.Id);
            order.Should().Be(null);
        }

    

    }
}