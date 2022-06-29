using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using SmartRestaurant.Application.Bills.Queries;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Orders.Queries;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Bills.Queries
{
    using static Testing;

    [TestFixture]
    public class GetBillByIdTest : TestBase
    {   
        [Test]
        public async Task GetOrderById_ShouldReturnselectedBill()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);


            var createFoodBusinessClientCommand = new CreateFoodBusinessClientCommand
            {
                Address = new AddressDto
                {
                    City = "Algiers",
                    Country = "Algeria",
                    GeoPosition = new GeoPositionDto
                    {
                        Latitude = "0",
                        Longitude = "0"
                    },
                    StreetAddress = "Didouche Mourad"
                },
                Description = "",
                Name = "G22 REI",
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                Email = "test@g22rei.com",
                Website = "http://g22rei.com",
                FoodBusinessId = fastFood.FoodBusinessId.ToString()
            };
            await SendAsync(createFoodBusinessClientCommand);



            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await CreateTable(createZoneCommand);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct();
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, createFoodBusinessClientCommand.Id.ToString(), createDishCommand, createProductCommand);

            var order = await GetOrder(createOrderCommand.Id);

            var selectedBill = await SendAsync(new GetBillByIdQuery { Id = order.OrderId.ToString() });


            selectedBill.Should().NotBeNull();

            selectedBill.Type.Should().Be(order.Type);
            selectedBill.Status.Should().Be(order.Status);
            selectedBill.CreatedAt.Should().Be(order.CreatedAt);
            selectedBill.TotalToPay.Should().Be(order.TotalToPay);
            selectedBill.Discount.Should().Be(order.Discount);
            selectedBill.Number.Should().Be(order.Number);
            selectedBill.OrderId.Should().Be(order.OrderId);

            selectedBill.FoodBusiness.FoodBusinessId.Should().Be(order.FoodBusiness.FoodBusinessId);
            selectedBill.FoodBusiness.Name.Should().Be(order.FoodBusiness.Name);
            selectedBill.FoodBusiness.Email.Should().Be(order.FoodBusiness.Email);
            selectedBill.FoodBusiness.Address.StreetAddress.Should().Be(order.FoodBusiness.Address.StreetAddress);
            selectedBill.FoodBusiness.Address.City.Should().Be(order.FoodBusiness.Address.City);
            selectedBill.FoodBusiness.Address.Country.Should().Be(order.FoodBusiness.Address.Country);
            selectedBill.FoodBusiness.PhoneNumber.CountryCode.Should().Be(order.FoodBusiness.PhoneNumber.CountryCode);
            selectedBill.FoodBusiness.PhoneNumber.Number.Should().Be(order.FoodBusiness.PhoneNumber.Number);
            selectedBill.FoodBusiness.Website.Should().Be(order.FoodBusiness.Website);
            selectedBill.FoodBusiness.DefaultCurrency.Should().Be(order.FoodBusiness.DefaultCurrency);

            selectedBill.FoodBusinessClient.FoodBusinessClientId.Should().Be(order.FoodBusinessClient.FoodBusinessClientId);
            selectedBill.FoodBusinessClient.Name.Should().Be(order.FoodBusinessClient.Name);
            selectedBill.FoodBusinessClient.Email.Should().Be(order.FoodBusinessClient.Email);
            selectedBill.FoodBusinessClient.Address.StreetAddress.Should().Be(order.FoodBusinessClient.Address.StreetAddress);
            selectedBill.FoodBusinessClient.Address.City.Should().Be(order.FoodBusinessClient.Address.City);
            selectedBill.FoodBusinessClient.Address.Country.Should().Be(order.FoodBusinessClient.Address.Country);
            selectedBill.FoodBusinessClient.PhoneNumber.CountryCode.Should().Be(order.FoodBusinessClient.PhoneNumber.CountryCode);
            selectedBill.FoodBusinessClient.PhoneNumber.Number.Should().Be(order.FoodBusinessClient.PhoneNumber.Number);
            selectedBill.FoodBusinessClient.Website.Should().Be(order.FoodBusinessClient.Website);

            selectedBill.Tables[0].TableId.Should().Be(order.Products[0].TableId);
            selectedBill.Tables[0].TableNumber.Should().Be(order.Products[0].TableNumber);
            selectedBill.Tables[0].Chairs[0].Products[0].Name.Should().Be(order.Products[0].Name);
            selectedBill.Tables[0].Chairs[0].Products[0].InitialPrice.Should().Be(order.Products[0].InitialPrice);
            selectedBill.Tables[0].Chairs[0].Products[0].UnitPrice.Should().Be(order.Products[0].UnitPrice);
            selectedBill.Tables[0].Chairs[0].Products[0].Discount.Should().Be(order.Products[0].Discount);
            selectedBill.Tables[0].Chairs[0].Products[0].Quantity.Should().Be(order.Products[0].Quantity);

            selectedBill.Tables[0].TableId.Should().Be(order.Dishes[0].TableId);
            selectedBill.Tables[0].TableNumber.Should().Be(order.Dishes[0].TableNumber);
            selectedBill.Tables[0].Chairs[0].Dishes[0].Name.Should().Be(order.Dishes[0].Name);
            selectedBill.Tables[0].Chairs[0].Dishes[0].InitialPrice.Should().Be(order.Dishes[0].InitialPrice);
            selectedBill.Tables[0].Chairs[0].Dishes[0].UnitPrice.Should().Be(order.Dishes[0].UnitPrice);
            selectedBill.Tables[0].Chairs[0].Dishes[0].Discount.Should().Be(order.Dishes[0].Discount);
            selectedBill.Tables[0].Chairs[0].Dishes[0].Quantity.Should().Be(order.Dishes[0].Quantity);

            selectedBill.CommissionConfigs.Value.Should().Be(0);
            selectedBill.CommissionConfigs.Type.Should().Be(CommissionType.PerPerson);
            selectedBill.CommissionConfigs.WhoPay.Should().Be(WhoPayCommission.FoodBusiness);

        }

        private static async Task CreateTable(CreateZoneCommand createZoneCommand)
        {
            var createTableCommand01 = new CreateTableCommand
            {
                Id = Guid.Parse("44aecd78-59bb-7504-bfff-07c07129ab00"),
                Capacity = 4,
                ZoneId = createZoneCommand.Id.ToString()
            };
            await SendAsync(createTableCommand01);
        }


    }
}
