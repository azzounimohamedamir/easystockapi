using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using FluentAssertions;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System.Collections.Generic;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.Bills.Commands;
using SmartRestaurant.Application.Common.Dtos.BillDtos;

namespace SmartRestaurant.Application.IntegrationTests.Bills.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateBillTest : TestBase
    {
        OrderDishSpecificationDto CheckBoxModified = new OrderDishSpecificationDto()
        {
            Title = "Spicy Modified",
            ContentType = ContentType.CheckBox,
            CheckBoxContent = false,
            ComboBoxContent = null,
            CheckBoxSelection = true,
            ComboBoxSelection = null
        };

        OrderDishSpecificationDto ComboBoxModified = new OrderDishSpecificationDto()
        {
            Title = "Cuisson Modified",
            ContentType = ContentType.ComboBox,
            CheckBoxContent = true,
            ComboBoxContent = new List<string>() { "Bien Cuite Modified", "Demi cuisson Modified" },
            CheckBoxSelection = false,
            ComboBoxSelection = "Demi cuisson Modified"
        };

        OrderDishIngredientDto IngredientModified = new OrderDishIngredientDto()
        {
            IsPrimary = false,
            Amount = 15,
            MinimumAmount = 10,
            MaximumAmount = 20,
            AmountIncreasePerStep = 5,
            PriceIncreasePerStep = 3,
            MeasurementUnits = MeasurementUnits.MilliLiter,
            Steps = 2,
            OrderIngredient = new OrderIngredientDto()
            {
                IngredientId = "72867405-75a6-44bc-ac82-407ea918c8dc",
                Names = new List<IngredientNameDto>{
                    new IngredientNameDto() {Name = "Cooking oil Modified",Language = "en"},
                    new IngredientNameDto() {Name = "Modified زيت الطهي",Language = "ar"},
                    new IngredientNameDto() {Name = "Huile Modified",Language = "fr"}
                    },
                EnergeticValue = new EnergeticValueDto
                {
                    Fat = 1,
                    Protein = 1,
                    Carbohydrates = 1,
                    Energy = 10,
                    Amount = 0.5f,
                    MeasurementUnit = MeasurementUnits.MilliLiter
                }
            }
        };

        OrderDishSupplementDto SupplementModified = new OrderDishSupplementDto()
        {
            SupplementId = "e66f88b3-f39a-4301-97f0-471ad7f07e66",
            Name = "French Fries Modified",
            Price = 100,
            EnergeticValue = 250,
            Description = "TEST Modified",
            IsSelected = false
        };


        [Test]
        public async Task UpdateBill_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var foodBusinessClient = await CreateFoodBusinessClient(fastFood);
            var createZoneCommand = await CreateZone(fastFood);
            await CreateTable(createZoneCommand);

            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId);

            var updateOrderBillCommand = await UpdateBill(await GetOrder(createOrderCommand.Id));

            var order = await GetOrder(Guid.Parse(updateOrderBillCommand.Id));
            order.OrderId.Should().Be(createOrderCommand.Id);
            order.Discount.Should().Be(50);
            order.TotalToPay.Should().Be(190);
            order.FoodBusinessId.Should().Be(order.FoodBusinessId);

            order.FoodBusinessClientId.Should().Be(order.FoodBusinessClientId);
            order.OccupiedTables[0].TableId.Should().Be(order.OccupiedTables[0].TableId);
            order.Products[0].Name.Should().Be(order.Products[0].Name);
            order.Products[0].UnitPrice.Should().Be(order.Products[0].UnitPrice);
            order.Products[0].Discount.Should().Be(50);
            order.Products[0].EnergeticValue.Should().Be(order.Products[0].EnergeticValue);
            order.Products[0].Description.Should().Be(order.Products[0].Description);
            order.Products[0].TableNumber.Should().Be(order.Products[0].TableNumber);
            order.Products[0].ChairNumber.Should().Be(order.Products[0].ChairNumber);
            order.Products[0].Quantity.Should().Be(order.Products[0].Quantity);

            order.Dishes[0].Name.Should().Be(order.Dishes[0].Name);
            order.Dishes[0].Discount.Should().Be(50);
            order.Dishes[0].InitialPrice.Should().Be(order.Dishes[0].InitialPrice);
            order.Dishes[0].UnitPrice.Should().Be(320);
            order.Dishes[0].EnergeticValue.Should().Be(order.Dishes[0].EnergeticValue);
            order.Dishes[0].Description.Should().Be(order.Dishes[0].Description);
            order.Dishes[0].EstimatedPreparationTime.Should().Be(order.Dishes[0].EstimatedPreparationTime);
            order.Dishes[0].TableNumber.Should().Be(order.Dishes[0].TableNumber);
            order.Dishes[0].ChairNumber.Should().Be(order.Dishes[0].ChairNumber);
            order.Dishes[0].Quantity.Should().Be(order.Dishes[0].Quantity);

            order.Dishes[0].Specifications[0].Title.Should().Be(order.Dishes[0].Specifications[0].Title);
            order.Dishes[0].Specifications[0].ContentType.Should().Be(order.Dishes[0].Specifications[0].ContentType);
            order.Dishes[0].Specifications[0].ComboBoxContent.Should().BeNull();
            order.Dishes[0].Specifications[0].ComboBoxSelection.Should().Be(order.Dishes[0].Specifications[0].ComboBoxSelection); ; ; ; ; ; ; ;
            order.Dishes[0].Specifications[0].CheckBoxContent.Should().Be(order.Dishes[0].Specifications[0].CheckBoxContent);
            order.Dishes[0].Specifications[0].CheckBoxSelection.Should().Be(order.Dishes[0].Specifications[0].CheckBoxSelection);
            order.Dishes[0].Specifications[1].Title.Should().Be(order.Dishes[0].Specifications[1].Title);
            order.Dishes[0].Specifications[1].ContentType.Should().Be(order.Dishes[0].Specifications[1].ContentType);
            order.Dishes[0].Specifications[1].ComboBoxContent.Should().Be(string.Join(";", order.Dishes[0].Specifications[1].ComboBoxContent));
            order.Dishes[0].Specifications[1].ComboBoxSelection.Should().Be(order.Dishes[0].Specifications[1].ComboBoxSelection);
            order.Dishes[0].Specifications[1].CheckBoxContent.Should().Be(order.Dishes[0].Specifications[1].CheckBoxContent);
            order.Dishes[0].Specifications[1].CheckBoxSelection.Should().Be(order.Dishes[0].Specifications[1].CheckBoxSelection);

            order.Dishes[0].Ingredients[0].IsPrimary.Should().Be(order.Dishes[0].Ingredients[0].IsPrimary);
            order.Dishes[0].Ingredients[0].Amount.Should().Be(order.Dishes[0].Ingredients[0].Amount);
            order.Dishes[0].Ingredients[0].MinimumAmount.Should().Be(order.Dishes[0].Ingredients[0].MinimumAmount);
            order.Dishes[0].Ingredients[0].MaximumAmount.Should().Be(order.Dishes[0].Ingredients[0].MaximumAmount);
            order.Dishes[0].Ingredients[0].AmountIncreasePerStep.Should().Be(order.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            order.Dishes[0].Ingredients[0].PriceIncreasePerStep.Should().Be(order.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            order.Dishes[0].Ingredients[0].Steps.Should().Be(order.Dishes[0].Ingredients[0].Steps);
            order.Dishes[0].Ingredients[0].MeasurementUnits.Should().Be(order.Dishes[0].Ingredients[0].MeasurementUnits);
            order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            order.Dishes[0].Ingredients[0].OrderIngredient.Names.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.Names);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            order.Dishes[0].Supplements[0].SupplementId.Should().Be(order.Dishes[0].Supplements[0].SupplementId);
            order.Dishes[0].Supplements[0].Name.Should().Be(order.Dishes[0].Supplements[0].Name);
            order.Dishes[0].Supplements[0].Price.Should().Be(order.Dishes[0].Supplements[0].Price);
            order.Dishes[0].Supplements[0].EnergeticValue.Should().Be(order.Dishes[0].Supplements[0].EnergeticValue);
            order.Dishes[0].Supplements[0].Description.Should().Be(order.Dishes[0].Supplements[0].Description);
            order.Dishes[0].Supplements[0].IsSelected.Should().Be(order.Dishes[0].Supplements[0].IsSelected);
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

        private static async Task<CreateZoneCommand> CreateZone(Domain.Entities.FoodBusiness fastFood)
        {
            var createZoneCommand = new CreateZoneCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "zone 45"
            };
            await SendAsync(createZoneCommand);
            return createZoneCommand;
        }

        private async Task<UpdateBillCommand> UpdateBill(Order order)
        {
            var updateBillCommand = new UpdateBillCommand
            {
                Id = order.OrderId.ToString(),
                Discount = 50,

                Dishes = new List<BillDishCommandDto>() {
                new BillDishCommandDto {
                    OrderDishId = order.Dishes[0].OrderDishId.ToString(),
                    Discount = 50
                    }
                },
                Products = new List<BillProductCommandDto>() {
                new BillProductCommandDto {
                    OrderProductId =  order.Products[0].OrderProductId.ToString(),
                    Discount =  50,                   
                    }
                }
            };
            await SendAsync(updateBillCommand);
            return updateBillCommand;
        }
    }
}