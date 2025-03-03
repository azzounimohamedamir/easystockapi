﻿using FluentAssertions;
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
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await TablesTestTools.CreateTable(createZoneCommand);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);


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

        

    }
}
