using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Zones.Queries
{
    using static Testing;

    public class GetZonesListWithNumberOfOrdersQueryTest : TestBase
    {
        [Test]
        public async Task ShouldReturnAllListWithNumberOfOrders()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await CreateTable(createZoneCommand);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct();
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);
            var query = new GetZonesListWithNumberOfOrdersQuery { FoodBusinessId = fastFood.FoodBusinessId.ToString()};
            var result = await SendAsync(query);
            result.Should().NotBeNull();
            var enumirator = result.GetEnumerator();

            result.Should().HaveCount(2);
            foreach (var item in result)    
            {
                item.ZoneTitle.Should().Equals("ZoneTitle");

                 item.ZoneId.Should().Equals(createZoneCommand.Id.ToString());
            }
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

    }
}