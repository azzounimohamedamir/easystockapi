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
    public class GetOrdersListByDinerOrHotelClientTest : TestBase
    {   
        [Test]
        public async Task ShouldGetOrdersListByDinerOrHotelClientTest()
        {
            await RolesTestTools.CreateRoles();
            var Diner02 = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(Diner02.Id);
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await TablesTestTools.CreateTable(createZoneCommand);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);
            var orderListOfDiner = await SendAsync(new GetOrdersListByDinnerOrClientQuery { });
            orderListOfDiner.Data.Should().HaveCount(1);
           
        }

       


    }
}
