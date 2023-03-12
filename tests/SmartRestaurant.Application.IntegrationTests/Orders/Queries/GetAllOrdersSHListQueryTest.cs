using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Orders.Queries;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Domain.Identity.Enums;
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
            await TablesTestTools.CreateTable(createZoneCommand);
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
            ConfigureRoleClient(Roles.Diner.ToString());

            var orderListOfClientSH = await SendAsync(new GetAllClientSHOrdersQuery { HotelId=OrderSHForRestauranthotelDinIn.HotelId.ToString() });
            orderListOfClientSH.Data.Should().HaveCount(1);
            ConfigureRoleClient(Roles.FoodBusinessAdministrator.ToString());
        }
        
    }
}
