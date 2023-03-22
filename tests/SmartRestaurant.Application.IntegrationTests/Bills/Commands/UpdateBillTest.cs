using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using FluentAssertions;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System.Collections.Generic;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.Bills.Commands;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using Newtonsoft.Json;

namespace SmartRestaurant.Application.IntegrationTests.Bills.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateBillTest : TestBase
    {
        [Test]
        public async Task UpdateBill_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var foodBusinessClient = await CreateFoodBusinessClient(fastFood);
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await CreateTable(createZoneCommand);

            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);

            var updateOrderBillCommand = await UpdateBill(await GetOrder(createOrderCommand.Id));
            var getUsedSuppliment = await GetDish(Guid.Parse(createOrderCommand.Dishes[0].Supplements[0].SupplementId));

            var order = await GetOrder(Guid.Parse(updateOrderBillCommand.Id));
            order.OrderId.Should().Be(createOrderCommand.Id);
            order.Discount.Should().Be(50);
            order.TotalToPay.Should().Be(760);
            order.FoodBusinessId.Should().Be(createOrderCommand.FoodBusinessId);

            order.OccupiedTables[0].TableId.Should().Be(createOrderCommand.OccupiedTables[0].TableId);
            order.Products[0].Name.Should().Be(createProductCommand.Name);

            order.Products[0].Names.AR.Should().Be(createProductCommand.Names.AR);
            order.Products[0].Names.EN.Should().Be(createProductCommand.Names.EN);
            order.Products[0].Names.FR.Should().Be(createProductCommand.Names.FR);
            order.Products[0].Names.TR.Should().Be(createProductCommand.Names.TR);
            order.Products[0].Names.RU.Should().Be(createProductCommand.Names.RU);

            order.Products[0].UnitPrice.Should().Be(createProductCommand.Price);
            order.Products[0].Discount.Should().Be(50);
            order.Products[0].EnergeticValue.Should().Be(createProductCommand.EnergeticValue);
            order.Products[0].Description.Should().Be(createProductCommand.Description);
            order.Products[0].TableNumber.Should().Be(createOrderCommand.Products[0].TableNumber);
            order.Products[0].ChairNumber.Should().Be(createOrderCommand.Products[0].ChairNumber);
            order.Products[0].Quantity.Should().Be(createOrderCommand.Products[0].Quantity);

            order.Dishes[0].Name.Should().Be(createDishCommand.Name);
            order.Dishes[0].Names.AR.Should().Be(createDishCommand.Names.AR);
            order.Dishes[0].Names.EN.Should().Be(createDishCommand.Names.EN);
            order.Dishes[0].Names.FR.Should().Be(createDishCommand.Names.FR);
            order.Dishes[0].Names.TR.Should().Be(createDishCommand.Names.TR);
            order.Dishes[0].Names.RU.Should().Be(createDishCommand.Names.RU);

            order.Dishes[0].Discount.Should().Be(50);
            order.Dishes[0].InitialPrice.Should().Be(createDishCommand.Price);
            order.Dishes[0].UnitPrice.Should().Be(380);
            order.Dishes[0].EnergeticValue.Should().Be(createOrderCommand.Dishes[0].EnergeticValue);
            order.Dishes[0].Description.Should().Be(createDishCommand.Description);
            order.Dishes[0].EstimatedPreparationTime.Should().Be(createDishCommand.EstimatedPreparationTime);
            order.Dishes[0].TableNumber.Should().Be(createOrderCommand.Dishes[0].TableNumber);
            order.Dishes[0].ChairNumber.Should().Be(createOrderCommand.Dishes[0].ChairNumber);
            order.Dishes[0].Quantity.Should().Be(createOrderCommand.Dishes[0].Quantity);

            order.Dishes[0].Specifications[0].Title.Should().Be(createOrderCommand.Dishes[0].Specifications[0].Title);
            order.Dishes[0].Specifications[0].Names.AR.Should().Be(createOrderCommand.Dishes[0].Specifications[0].Names.AR);
            order.Dishes[0].Specifications[0].Names.EN.Should().Be(createOrderCommand.Dishes[0].Specifications[0].Names.EN);
            order.Dishes[0].Specifications[0].Names.FR.Should().Be(createOrderCommand.Dishes[0].Specifications[0].Names.FR);
            order.Dishes[0].Specifications[0].Names.TR.Should().Be(createOrderCommand.Dishes[0].Specifications[0].Names.TR);
            order.Dishes[0].Specifications[0].Names.RU.Should().Be(createOrderCommand.Dishes[0].Specifications[0].Names.RU);

            order.Dishes[0].Specifications[0].ContentType.Should().Be(createOrderCommand.Dishes[0].Specifications[0].ContentType);
            order.Dishes[0].Specifications[0].ComboBoxContent.Should().BeNull();
            order.Dishes[0].Specifications[0].ComboBoxSelection.Should().Be(createOrderCommand.Dishes[0].Specifications[0].ComboBoxSelection);
            order.Dishes[0].Specifications[0].CheckBoxContent.Should().Be(createOrderCommand.Dishes[0].Specifications[0].CheckBoxContent);
            order.Dishes[0].Specifications[0].CheckBoxSelection.Should().Be(createOrderCommand.Dishes[0].Specifications[0].CheckBoxSelection);
            order.Dishes[0].Specifications[1].Title.Should().Be(createOrderCommand.Dishes[0].Specifications[1].Title);
            order.Dishes[0].Specifications[1].ContentType.Should().Be(createOrderCommand.Dishes[0].Specifications[1].ContentType);

            order.Dishes[0].Specifications[1].ComboBoxSelection.Should().Be(createOrderCommand.Dishes[0].Specifications[1].ComboBoxSelection);
            order.Dishes[0].Specifications[1].CheckBoxContent.Should().Be(createOrderCommand.Dishes[0].Specifications[1].CheckBoxContent);
            order.Dishes[0].Specifications[1].CheckBoxSelection.Should().Be(createOrderCommand.Dishes[0].Specifications[1].CheckBoxSelection);

            order.Dishes[0].Ingredients[0].IsPrimary.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].IsPrimary);
            order.Dishes[0].Ingredients[0].Amount.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].Amount);
            order.Dishes[0].Ingredients[0].MinimumAmount.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].MinimumAmount);
            order.Dishes[0].Ingredients[0].MaximumAmount.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].MaximumAmount);
            order.Dishes[0].Ingredients[0].AmountIncreasePerStep.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            order.Dishes[0].Ingredients[0].PriceIncreasePerStep.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            order.Dishes[0].Ingredients[0].Steps.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].Steps);
            order.Dishes[0].Ingredients[0].MeasurementUnits.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].MeasurementUnits);
            order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            order.Dishes[0].Ingredients[0].OrderIngredient.Names.Should().Be(JsonConvert.SerializeObject(createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names));
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit.Should().Be(createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            order.Dishes[0].Supplements[0].SupplementId.Should().Be(getUsedSuppliment.DishId.ToString());
            order.Dishes[0].Supplements[0].Name.Should().Be(getUsedSuppliment.Name);
            
            order.Dishes[0].Supplements[0].Names.AR.Should().Be(getUsedSuppliment.Names.AR);
            order.Dishes[0].Supplements[0].Names.EN.Should().Be(getUsedSuppliment.Names.EN);
            order.Dishes[0].Supplements[0].Names.FR.Should().Be(getUsedSuppliment.Names.FR);
            order.Dishes[0].Supplements[0].Names.TR.Should().Be(getUsedSuppliment.Names.TR);
            order.Dishes[0].Supplements[0].Names.RU.Should().Be(getUsedSuppliment.Names.RU);

            order.Dishes[0].Supplements[0].Price.Should().Be(getUsedSuppliment.Price);
            order.Dishes[0].Supplements[0].EnergeticValue.Should().Be(getUsedSuppliment.EnergeticValue);
            order.Dishes[0].Supplements[0].Description.Should().Be(getUsedSuppliment.Description);
            order.Dishes[0].Supplements[0].IsSelected.Should().Be(createOrderCommand.Dishes[0].Supplements[0].IsSelected);
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