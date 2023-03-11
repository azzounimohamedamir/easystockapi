using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Orders.Queries;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Queries
{
    using static Testing;

    [TestFixture]
    public class GetAllOrdersSHListQueryTest : TestBase

    {
        [Test]

        public async Task ShouldGetOrdersListByDinerOrHotelClientTest()
        {
            await RolesTestTools.CreateRoles();
            var adminmanager = await UsersTestTools.CreateFoodBusinessAdministrator();
            var client = await UsersTestTools.CreateClient(_authenticatedUserId);

            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(adminmanager.Id);
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await CreateTable(createZoneCommand);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();


            var hotel = await HotelTestTools.CreateHotel(client.Id, "Shiraton");
            var building = await BuildingTestTools.CreateBuilding("building1", hotel.Id);
            var room = await RoomTestTools.CreateRoomForClient(2, building.Id, client.Id);
            var createSheratonMallSection = await HotelSectionTestTools.CreateHotelSectionByHotelid(hotel.Id);
            var createRestaurantMallService = await HotelServicesTestTools.CreateHotelServiceBySectionId(createSheratonMallSection.Id, fastFood.FoodBusinessId.ToString());
            var checkin = await CheckInsTestTools.CreateCheckinForClient(hotel.Id, client.Id, room.Id);
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct();

            var OrderSHForRestauranthotelDinIn = await OrderTestTools.CreateOrderSH(createDishCommand, createProductCommand, fastFood, createRestaurantMallService, checkin, hotel);
            ConfigureRoleClient("Diner");

            var orderListOfClientSH = await SendAsync(new GetAllClientSHOrdersQuery { HotelId=OrderSHForRestauranthotelDinIn.HotelId.ToString() });
            orderListOfClientSH.Data.Should().HaveCount(1);

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
