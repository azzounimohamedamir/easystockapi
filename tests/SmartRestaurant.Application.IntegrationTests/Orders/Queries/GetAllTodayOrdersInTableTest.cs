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
    public class GetAllTodayOrdersInTableTest : TestBase
    {
        [Test]
        public async Task ShouldGetAllTodayOrdersListByTableIdTest()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessAdmin = await UsersTestTools.CreateFoodBusinessAdministrator();

            var member_1_OfTable1 = await UsersTestTools.CreateDinner("member_1_OfTable1");
            var member_2_OfTable1 = await UsersTestTools.CreateDinner("member_2_OfTable1");
            var member_1_OfTable2 = await UsersTestTools.CreateDinner("member_3_OfTable2");

            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodbusinessAdmin.Id);
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await CreateTable1(createZoneCommand);
            await CreateTable2(createZoneCommand);

            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);



            var createOrderCommand_for_member_1_OfTable1 = await OrderTestTools.CreateOrderInTable(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand, "44aecd78-59bb-7504-bfff-07c07129ab00",1) ;
            var createOrderCommand_for_member_2_OfTable1 = await OrderTestTools.CreateOrderInTable(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand, "44aecd78-59bb-7504-bfff-07c07129ab00", 2);
            var createOrderCommand_for_member_1_OfTable2 = await OrderTestTools.CreateOrderInTable(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand, "44aecd78-59bb-7504-bfff-07c07129ab01", 1);

            var orderListOfTable1 = await SendAsync(new GetAllTodayOrdersQueryByTableId { TableId = Guid.Parse("44aecd78-59bb-7504-bfff-07c07129ab00") });
            orderListOfTable1.Data.Should().HaveCount(2);
            orderListOfTable1.Data[0].CreatedAt.Date.Should().Be(DateTime.Now.Date);
            orderListOfTable1.Data[1].CreatedAt.Date.Should().Be(DateTime.Now.Date);
            orderListOfTable1.Data[0].OccupiedTables[0].TableId.Should().Be("44aecd78-59bb-7504-bfff-07c07129ab00");
            orderListOfTable1.Data[1].OccupiedTables[0].TableId.Should().Be("44aecd78-59bb-7504-bfff-07c07129ab00");

        }

        private static async Task CreateTable1(CreateZoneCommand createZoneCommand)
        {
            var createTableCommand = new CreateTableCommand
            {
                Id = Guid.Parse("44aecd78-59bb-7504-bfff-07c07129ab00"),
                Capacity = 4,
                ZoneId = createZoneCommand.Id.ToString()
            };
            await SendAsync(createTableCommand);
        }

        private static async Task CreateTable2(CreateZoneCommand createZoneCommand)
        {
            var createTableCommand = new CreateTableCommand
            {
                Id = Guid.Parse("44aecd78-59bb-7504-bfff-07c07129ab01"),
                Capacity = 4,
                ZoneId = createZoneCommand.Id.ToString()
            };
            await SendAsync(createTableCommand);
        }


    }
}
