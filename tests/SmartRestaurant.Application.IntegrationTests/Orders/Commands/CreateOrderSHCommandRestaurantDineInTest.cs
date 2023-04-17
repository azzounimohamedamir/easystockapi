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
    public class CreateOrderSHCommandRestaurantDineInTest : TestBase
    {
        [Test]
        public async Task CreateOrderSHCommandRestaurantDineInTestShouldSaveToBdd()
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
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);


            var OrderSHForRestauranthotelDinIn = await OrderTestTools.CreateOrderSHForDineIn(createDishCommand,createProductCommand, fastFood, createRestaurantMallService, checkin, hotel); 
            

            // GET Orders data from Order Table with SmartRestaurantOrderId in DineIn and InRoom 

            var OrderSHForRestauranthotelDinInSavedInTableOrder = await GetOrder(OrderSHForRestauranthotelDinIn.SmartRestaurentOrderId);


            // ORDER DINEIN RESTAURANT TESTS 

            OrderSHForRestauranthotelDinIn.HotelId.Should().Be(hotel.Id.ToString());
            OrderSHForRestauranthotelDinIn.IsSmartrestaurantMenue.Should().Be(true);
            OrderSHForRestauranthotelDinIn.ChairNumber.Should().Be(1);
            OrderSHForRestauranthotelDinIn.CheckIn.RoomNumber.Should().Be(checkin.RoomNumber);
            OrderSHForRestauranthotelDinIn.CheckIn.RoomId.Should().Be(checkin.RoomId);
            OrderSHForRestauranthotelDinIn.CheckIn.PhoneNumber.Should().Be(checkin.PhoneNumber);
            OrderSHForRestauranthotelDinIn.CheckIn.Startdate.Should().Be(checkin.Startdate);
            OrderSHForRestauranthotelDinIn.FoodBusinessId.Should().Be(fastFood.FoodBusinessId);
            OrderSHForRestauranthotelDinIn.HotelId.Should().Be(hotel.Id);
            OrderSHForRestauranthotelDinIn.Names.AR.Should().Be(createRestaurantMallService.Names.AR);
            OrderSHForRestauranthotelDinIn.Names.EN.Should().Be(createRestaurantMallService.Names.EN);
            OrderSHForRestauranthotelDinIn.Names.FR.Should().Be(createRestaurantMallService.Names.FR);
            OrderSHForRestauranthotelDinIn.Names.TR.Should().Be(createRestaurantMallService.Names.TR);
            OrderSHForRestauranthotelDinIn.Names.RU.Should().Be(createRestaurantMallService.Names.RU);
            OrderSHForRestauranthotelDinIn.SuccesMessage.AR.Should().Be(createRestaurantMallService.TitelSeccesResponce.AR);
            OrderSHForRestauranthotelDinIn.SuccesMessage.EN.Should().Be(createRestaurantMallService.TitelSeccesResponce.EN);
            OrderSHForRestauranthotelDinIn.SuccesMessage.FR.Should().Be(createRestaurantMallService.TitelSeccesResponce.FR);
            OrderSHForRestauranthotelDinIn.SuccesMessage.TR.Should().Be(createRestaurantMallService.TitelSeccesResponce.TR);
            OrderSHForRestauranthotelDinIn.SuccesMessage.RU.Should().Be(createRestaurantMallService.TitelSeccesResponce.RU);
            OrderSHForRestauranthotelDinIn.FailureMessage.AR.Should().Be(createRestaurantMallService.TitelFailureResponce.AR);
            OrderSHForRestauranthotelDinIn.FailureMessage.EN.Should().Be(createRestaurantMallService.TitelFailureResponce.EN);
            OrderSHForRestauranthotelDinIn.FailureMessage.FR.Should().Be(createRestaurantMallService.TitelFailureResponce.FR);
            OrderSHForRestauranthotelDinIn.FailureMessage.TR.Should().Be(createRestaurantMallService.TitelFailureResponce.TR);
            OrderSHForRestauranthotelDinIn.FailureMessage.RU.Should().Be(createRestaurantMallService.TitelFailureResponce.RU);
            OrderSHForRestauranthotelDinIn.RoomId.Should().Be(checkin.RoomId);
            OrderSHForRestauranthotelDinIn.TableId.Should().Be(OrderSHForRestauranthotelDinInSavedInTableOrder.OccupiedTables[0].TableId);
            OrderSHForRestauranthotelDinIn.Type.Should().Be(OrderTypes.DineIn);
            OrderSHForRestauranthotelDinIn.OrderStat.Should().Be(SHOrderStat.IsNew);
            OrderSHForRestauranthotelDinIn.UserId.Should().Be(checkin.ClientId);
            OrderSHForRestauranthotelDinIn.SmartRestaurentOrderId.Should().Be(OrderSHForRestauranthotelDinInSavedInTableOrder.OrderId);



         







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