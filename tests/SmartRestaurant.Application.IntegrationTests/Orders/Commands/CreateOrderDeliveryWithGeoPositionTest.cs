using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using FluentAssertions;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateOrderDeliveryWithGeoPositionTest : TestBase
    {
        [Test]
        public async Task CreateOrderDeliveryWithGeoPosition_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct();
            DateTime orderTime = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            ConfigureDateTimeNow(orderTime);

           
          

           
            var OrderCommand = await OrderTestTools.CreateOrderDelivery(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand,"48.8582", "2.2945");

            OrderCommand.ErrorDeliveryTimeAvailabilite.Should().Be(ErrorResult.None);

            var order = await GetOrder(Guid.Parse(OrderCommand.OrderId));


            order.Type.Should().Be(OrderTypes.Delivery);
            order.Status.Should().Be(OrderStatuses.InQueue);
            order.FoodBusinessId.Should().Be(Guid.Parse(OrderCommand.FoodBusinessId));
            order.FoodBusinessClientId.Should().BeNull();
           
            order.GeoPosition.Latitude.Should().Be("48.8582");
             order.GeoPosition.Longitude.Should().Be("2.2945");

        }


    }


}
