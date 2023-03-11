using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using FluentAssertions;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Tables.Commands;
using Newtonsoft.Json;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.Common.Dtos;
using System.Collections.Generic;
using SmartRestaurant.Domain.Common.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateOrderSHCommandRestaurantInRoom : TestBase
    {
        [Test]
        public async Task CreateOrderSHCommandRestaurantInRoomShouldSaveToBdd()
        {
            await RolesTestTools.CreateRoles();
            var client = await UsersTestTools.CreateClient(_authenticatedUserId);
            var adminmanager = await UsersTestTools.CreateFoodBusinessAdministrator();

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


            var OrderSHForRestauranthotelInRoom = await OrderTestTools.CreateOrderSHInRoom(createDishCommand, createProductCommand, fastFood, createRestaurantMallService, checkin, hotel); 

            // GET Orders data from Order Table with SmartRestaurantOrderId InRoom 

            var OrderSHForRestauranthotelInRoomSavedInTableOrder = await GetOrder(OrderSHForRestauranthotelInRoom.SmartRestaurentOrderId);

            // ORDER IN ROOM TESTS 

            OrderSHForRestauranthotelInRoom.HotelId.Should().Be(hotel.Id.ToString());
            OrderSHForRestauranthotelInRoom.IsSmartrestaurantMenue.Should().Be(true);
            OrderSHForRestauranthotelInRoom.ChairNumber.Should().Be(0);
            OrderSHForRestauranthotelInRoom.CheckIn.RoomNumber.Should().Be(checkin.RoomNumber);
            OrderSHForRestauranthotelInRoom.CheckIn.RoomId.Should().Be(checkin.RoomId);
            OrderSHForRestauranthotelInRoom.CheckIn.PhoneNumber.Should().Be(checkin.PhoneNumber);
            OrderSHForRestauranthotelInRoom.CheckIn.Startdate.Should().Be(checkin.Startdate);
            OrderSHForRestauranthotelInRoom.FoodBusinessId.Should().Be(fastFood.FoodBusinessId);
            OrderSHForRestauranthotelInRoom.Names.AR.Should().Be(createRestaurantMallService.Names.AR);
            OrderSHForRestauranthotelInRoom.Names.EN.Should().Be(createRestaurantMallService.Names.EN);
            OrderSHForRestauranthotelInRoom.Names.FR.Should().Be(createRestaurantMallService.Names.FR);
            OrderSHForRestauranthotelInRoom.Names.TR.Should().Be(createRestaurantMallService.Names.TR);
            OrderSHForRestauranthotelInRoom.Names.RU.Should().Be(createRestaurantMallService.Names.RU);
            OrderSHForRestauranthotelInRoom.SuccesMessage.AR.Should().Be(createRestaurantMallService.TitelSeccesResponce.AR);
            OrderSHForRestauranthotelInRoom.SuccesMessage.EN.Should().Be(createRestaurantMallService.TitelSeccesResponce.EN);
            OrderSHForRestauranthotelInRoom.SuccesMessage.FR.Should().Be(createRestaurantMallService.TitelSeccesResponce.FR);
            OrderSHForRestauranthotelInRoom.SuccesMessage.TR.Should().Be(createRestaurantMallService.TitelSeccesResponce.TR);
            OrderSHForRestauranthotelInRoom.SuccesMessage.RU.Should().Be(createRestaurantMallService.TitelSeccesResponce.RU);
            OrderSHForRestauranthotelInRoom.FailureMessage.AR.Should().Be(createRestaurantMallService.TitelFailureResponce.AR);
            OrderSHForRestauranthotelInRoom.FailureMessage.EN.Should().Be(createRestaurantMallService.TitelFailureResponce.EN);
            OrderSHForRestauranthotelInRoom.FailureMessage.FR.Should().Be(createRestaurantMallService.TitelFailureResponce.FR);
            OrderSHForRestauranthotelInRoom.FailureMessage.TR.Should().Be(createRestaurantMallService.TitelFailureResponce.TR);
            OrderSHForRestauranthotelInRoom.FailureMessage.RU.Should().Be(createRestaurantMallService.TitelFailureResponce.RU);
            OrderSHForRestauranthotelInRoom.TableId.Should().Be(Guid.Empty);
            OrderSHForRestauranthotelInRoom.Type.Should().Be(OrderTypes.InRoom);
            OrderSHForRestauranthotelInRoom.OrderStat.Should().Be(SHOrderStat.IsNew);          
            OrderSHForRestauranthotelInRoom.UserId.Should().Be(checkin.ClientId);
            OrderSHForRestauranthotelInRoom.SmartRestaurentOrderId.Should().Be(OrderSHForRestauranthotelInRoomSavedInTableOrder.OrderId);

          











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