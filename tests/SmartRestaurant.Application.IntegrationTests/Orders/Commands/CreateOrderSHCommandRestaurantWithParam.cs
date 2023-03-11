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
    public class CreateOrderSHCommandRestaurantWithParam : TestBase
    {
        [Test]
        public async Task CreateOrderSHCommandRestaurantWithParamShouldSaveToBdd()
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
            var createParkingService = await HotelServicesTestTools.CreateHotelParkingServiceBySectionId(createSheratonMallSection.Id, fastFood.FoodBusinessId.ToString());
            var checkin = await CheckInsTestTools.CreateCheckinForClient(hotel.Id, client.Id, room.Id);
            

            // Create 3 command DinIn , InRoom and With params order 

            var OrderSHForHotelServiceWithParameteres = await OrderTestTools.CreateOrderSHwithparamvalue(fastFood, createParkingService, checkin, hotel);

          


            // ORDER SERVICE HOTEL WITH PARAMETERS TESTS 


            OrderSHForHotelServiceWithParameteres.HotelId.Should().Be(hotel.Id.ToString());
            OrderSHForHotelServiceWithParameteres.ParametreValueClient.Count.Should().Be(1);
            OrderSHForHotelServiceWithParameteres.ParametreValueClient[0].Names.AR.Should().Be("عدد الحصص");
            OrderSHForHotelServiceWithParameteres.ParametreValueClient[0].Names.FR.Should().Be("nombre de seance");
            OrderSHForHotelServiceWithParameteres.ParametreValueClient[0].Names.EN.Should().Be("number of seance");
            OrderSHForHotelServiceWithParameteres.ParametreValueClient[0].Names.TR.Should().Be("number of seance");
            OrderSHForHotelServiceWithParameteres.ParametreValueClient[0].Names.RU.Should().Be("number of seance");
            OrderSHForHotelServiceWithParameteres.ParametreValueClient[0].NumberValue.Should().Be(1);
            OrderSHForHotelServiceWithParameteres.ParametreValueClient[0].Date.Should().Be(null);
            OrderSHForHotelServiceWithParameteres.ParametreValueClient[0].SelectedValue.Should().Be(null);
            OrderSHForHotelServiceWithParameteres.RoomId.Should().Be(checkin.RoomId);
            OrderSHForHotelServiceWithParameteres.IsSmartrestaurantMenue.Should().Be(false);
            OrderSHForHotelServiceWithParameteres.ChairNumber.Should().Be(0);
            OrderSHForHotelServiceWithParameteres.CheckIn.PhoneNumber.Should().Be(checkin.PhoneNumber);
            OrderSHForHotelServiceWithParameteres.CheckIn.Startdate.Should().Be(checkin.Startdate);
            OrderSHForHotelServiceWithParameteres.FoodBusinessId.Should().Be(Guid.Empty);
            OrderSHForHotelServiceWithParameteres.Names.AR.Should().Be(createParkingService.Names.AR);
            OrderSHForHotelServiceWithParameteres.Names.EN.Should().Be(createParkingService.Names.EN);
            OrderSHForHotelServiceWithParameteres.Names.FR.Should().Be(createParkingService.Names.FR);
            OrderSHForHotelServiceWithParameteres.Names.TR.Should().Be(createParkingService.Names.TR);
            OrderSHForHotelServiceWithParameteres.Names.RU.Should().Be(createParkingService.Names.RU);
            OrderSHForHotelServiceWithParameteres.SuccesMessage.AR.Should().Be(createParkingService.TitelSeccesResponce.AR);
            OrderSHForHotelServiceWithParameteres.SuccesMessage.EN.Should().Be(createParkingService.TitelSeccesResponce.EN);
            OrderSHForHotelServiceWithParameteres.SuccesMessage.FR.Should().Be(createParkingService.TitelSeccesResponce.FR);
            OrderSHForHotelServiceWithParameteres.SuccesMessage.TR.Should().Be(createParkingService.TitelSeccesResponce.TR);
            OrderSHForHotelServiceWithParameteres.SuccesMessage.RU.Should().Be(createParkingService.TitelSeccesResponce.RU);
            OrderSHForHotelServiceWithParameteres.FailureMessage.AR.Should().Be(createParkingService.TitelFailureResponce.AR);
            OrderSHForHotelServiceWithParameteres.FailureMessage.EN.Should().Be(createParkingService.TitelFailureResponce.EN);
            OrderSHForHotelServiceWithParameteres.FailureMessage.FR.Should().Be(createParkingService.TitelFailureResponce.FR);
            OrderSHForHotelServiceWithParameteres.FailureMessage.TR.Should().Be(createParkingService.TitelFailureResponce.TR);
            OrderSHForHotelServiceWithParameteres.FailureMessage.RU.Should().Be(createParkingService.TitelFailureResponce.RU);
            OrderSHForHotelServiceWithParameteres.Type.Should().Be(OrderTypes.DineIn);
            OrderSHForHotelServiceWithParameteres.OrderStat.Should().Be(SHOrderStat.IsNew);
            OrderSHForHotelServiceWithParameteres.UserId.Should().Be(checkin.ClientId);
            OrderSHForHotelServiceWithParameteres.SmartRestaurentOrderId.Should().Be(Guid.Empty);














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