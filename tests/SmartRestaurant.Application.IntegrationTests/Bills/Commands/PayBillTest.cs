using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using FluentAssertions;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System.Collections.Generic;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.Bills.Commands;
using SmartRestaurant.Application.Common.Dtos.BillDtos;

namespace SmartRestaurant.Application.IntegrationTests.Bills.Commands
{
    using static Testing;

    [TestFixture]
    public class PayBillTest : TestBase
    {
        [Test]
        public async Task PayBill_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var foodBusinessClient = await CreateFoodBusinessClient(fastFood);
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await CreateTable(createZoneCommand);

            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, foodBusinessClient.FoodBusinessClientId.ToString());
            var orderBeforPayment = await GetOrder(createOrderCommand.Id);

            var PayBillCommand = await PayBill(await GetOrder(createOrderCommand.Id));

            var orderAfterPayment = await GetOrder(Guid.Parse(PayBillCommand.Id));
            orderAfterPayment.OrderId.Should().Be(orderBeforPayment.OrderId);
            orderAfterPayment.Status.Should().Be(OrderStatuses.Billed);
            orderAfterPayment.Discount.Should().Be(0);
            orderAfterPayment.TotalToPay.Should().Be(760);
            orderAfterPayment.FoodBusinessId.Should().Be(orderBeforPayment.FoodBusinessId);
            orderAfterPayment.FoodBusinessClientId.Should().Be(orderBeforPayment.FoodBusinessClientId);

            orderAfterPayment.FoodBusinessClientId.Should().Be(orderBeforPayment.FoodBusinessClientId);
            orderAfterPayment.OccupiedTables[0].TableId.Should().Be(orderBeforPayment.OccupiedTables[0].TableId);
            orderAfterPayment.Products[0].Name.Should().Be(orderBeforPayment.Products[0].Name);
            orderAfterPayment.Products[0].UnitPrice.Should().Be(orderBeforPayment.Products[0].UnitPrice);
            orderAfterPayment.Products[0].Discount.Should().Be(0);
            orderAfterPayment.Products[0].EnergeticValue.Should().Be(orderBeforPayment.Products[0].EnergeticValue);
            orderAfterPayment.Products[0].Description.Should().Be(orderBeforPayment.Products[0].Description);
            orderAfterPayment.Products[0].TableNumber.Should().Be(orderBeforPayment.Products[0].TableNumber);
            orderAfterPayment.Products[0].ChairNumber.Should().Be(orderBeforPayment.Products[0].ChairNumber);
            orderAfterPayment.Products[0].Quantity.Should().Be(orderBeforPayment.Products[0].Quantity);

            orderAfterPayment.Dishes[0].Name.Should().Be(orderBeforPayment.Dishes[0].Name);
            orderAfterPayment.Dishes[0].Discount.Should().Be(0);
            orderAfterPayment.Dishes[0].InitialPrice.Should().Be(orderBeforPayment.Dishes[0].InitialPrice);
            orderAfterPayment.Dishes[0].UnitPrice.Should().Be(320);
            orderAfterPayment.Dishes[0].EnergeticValue.Should().Be(orderBeforPayment.Dishes[0].EnergeticValue);
            orderAfterPayment.Dishes[0].Description.Should().Be(orderBeforPayment.Dishes[0].Description);
            orderAfterPayment.Dishes[0].EstimatedPreparationTime.Should().Be(orderBeforPayment.Dishes[0].EstimatedPreparationTime);
            orderAfterPayment.Dishes[0].TableNumber.Should().Be(orderBeforPayment.Dishes[0].TableNumber);
            orderAfterPayment.Dishes[0].ChairNumber.Should().Be(orderBeforPayment.Dishes[0].ChairNumber);
            orderAfterPayment.Dishes[0].Quantity.Should().Be(orderBeforPayment.Dishes[0].Quantity);

            orderAfterPayment.Dishes[0].Specifications[0].Title.Should().Be(orderBeforPayment.Dishes[0].Specifications[0].Title);
            orderAfterPayment.Dishes[0].Specifications[0].ContentType.Should().Be(orderBeforPayment.Dishes[0].Specifications[0].ContentType);
            orderAfterPayment.Dishes[0].Specifications[0].ComboBoxContent.Should().BeNull();
            orderAfterPayment.Dishes[0].Specifications[0].ComboBoxSelection.Should().Be(orderBeforPayment.Dishes[0].Specifications[0].ComboBoxSelection); ; ; ; ; ; ; ;
            orderAfterPayment.Dishes[0].Specifications[0].CheckBoxContent.Should().Be(orderBeforPayment.Dishes[0].Specifications[0].CheckBoxContent);
            orderAfterPayment.Dishes[0].Specifications[0].CheckBoxSelection.Should().Be(orderBeforPayment.Dishes[0].Specifications[0].CheckBoxSelection);
            orderAfterPayment.Dishes[0].Specifications[1].Title.Should().Be(orderBeforPayment.Dishes[0].Specifications[1].Title);
            orderAfterPayment.Dishes[0].Specifications[1].ContentType.Should().Be(orderBeforPayment.Dishes[0].Specifications[1].ContentType);
            orderAfterPayment.Dishes[0].Specifications[1].ComboBoxContent.Should().Be(string.Join(";", orderBeforPayment.Dishes[0].Specifications[1].ComboBoxContent));
            orderAfterPayment.Dishes[0].Specifications[1].ComboBoxSelection.Should().Be(orderBeforPayment.Dishes[0].Specifications[1].ComboBoxSelection);
            orderAfterPayment.Dishes[0].Specifications[1].CheckBoxContent.Should().Be(orderBeforPayment.Dishes[0].Specifications[1].CheckBoxContent);
            orderAfterPayment.Dishes[0].Specifications[1].CheckBoxSelection.Should().Be(orderBeforPayment.Dishes[0].Specifications[1].CheckBoxSelection);

            orderAfterPayment.Dishes[0].Ingredients[0].IsPrimary.Should().Be(orderAfterPayment.Dishes[0].Ingredients[0].IsPrimary);
            orderAfterPayment.Dishes[0].Ingredients[0].Amount.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].Amount);
            orderAfterPayment.Dishes[0].Ingredients[0].MinimumAmount.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].MinimumAmount);
            orderAfterPayment.Dishes[0].Ingredients[0].MaximumAmount.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].MaximumAmount);
            orderAfterPayment.Dishes[0].Ingredients[0].AmountIncreasePerStep.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            orderAfterPayment.Dishes[0].Ingredients[0].PriceIncreasePerStep.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            orderAfterPayment.Dishes[0].Ingredients[0].Steps.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].Steps);
            orderAfterPayment.Dishes[0].Ingredients[0].MeasurementUnits.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].MeasurementUnits);
            orderAfterPayment.Dishes[0].Ingredients[0].OrderIngredient.IngredientId.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            orderAfterPayment.Dishes[0].Ingredients[0].OrderIngredient.Names.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].OrderIngredient.Names);
            orderAfterPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            orderAfterPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            orderAfterPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            orderAfterPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            orderAfterPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            orderAfterPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit.Should().Be(orderBeforPayment.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            orderAfterPayment.Dishes[0].Supplements[0].SupplementId.Should().Be(orderBeforPayment.Dishes[0].Supplements[0].SupplementId);
            orderAfterPayment.Dishes[0].Supplements[0].Name.Should().Be(orderBeforPayment.Dishes[0].Supplements[0].Name);
            orderAfterPayment.Dishes[0].Supplements[0].Price.Should().Be(orderBeforPayment.Dishes[0].Supplements[0].Price);
            orderAfterPayment.Dishes[0].Supplements[0].EnergeticValue.Should().Be(orderBeforPayment.Dishes[0].Supplements[0].EnergeticValue);
            orderAfterPayment.Dishes[0].Supplements[0].Description.Should().Be(orderBeforPayment.Dishes[0].Supplements[0].Description);
            orderAfterPayment.Dishes[0].Supplements[0].IsSelected.Should().Be(orderBeforPayment.Dishes[0].Supplements[0].IsSelected);
        }

        private static async Task<Domain.Entities.FoodBusinessClient> CreateFoodBusinessClient(Domain.Entities.FoodBusiness fastFood)
        {
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
            return await FindAsync<Domain.Entities.FoodBusinessClient>(createFoodBusinessClientCommand.Id);

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

            var createTableCommand02 = new CreateTableCommand
            {
                Id = Guid.Parse("44aecd78-59bb-7504-bfff-07c07129ab20"),
                Capacity = 5,
                ZoneId = createZoneCommand.Id.ToString()
            };
            await SendAsync(createTableCommand02);
        }

        private async Task<PayBillCommand> PayBill(Order order)
        {
            var payBillCommand = new PayBillCommand
            {
                Id = order.OrderId.ToString(),
            };
            await SendAsync(payBillCommand);
            return payBillCommand;
        }
    }
}