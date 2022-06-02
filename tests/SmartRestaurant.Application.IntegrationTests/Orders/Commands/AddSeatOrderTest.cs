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
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Dtos;
using System.Collections.Generic;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Commands
{
    using static Testing;

    [TestFixture]
    public class AddSeatOrderTest : TestBase
    {
        [Test]
        public async Task AddSeatOrder_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await CreateTable(createZoneCommand);

            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null);

            var addSeatOrderCommand = await AddSeatOrderToTableOrder(createOrderCommand.Id.ToString(), "44aecd78-59bb-7504-bfff-07c07129ab00", 2);

            var order = await GetOrder(createOrderCommand.Id);
            var indexOfAddedOrder = 1;
            order.OrderId.Should().Be(createOrderCommand.Id);
          
            order.Type.Should().Be(OrderTypes.DineIn);
            order.Status.Should().Be(OrderStatuses.InQueue);
            order.FoodBusinessId.Should().Be(Guid.Parse(createOrderCommand.FoodBusinessId));
            order.FoodBusinessClientId.Should().BeNull();
            order.TotalToPay.Should().Be(2476);
            order.OccupiedTables[0].TableId.Should().Be(createOrderCommand.OccupiedTables[0].TableId);


            order.OccupiedTables[0].TableId.Should().Be(addSeatOrderCommand.TableId);
            order.Products[indexOfAddedOrder].Name.Should().Be(addSeatOrderCommand.Products[0].Name);
            order.Products[indexOfAddedOrder].UnitPrice.Should().Be(addSeatOrderCommand.Products[0].UnitPrice);
            order.Products[indexOfAddedOrder].EnergeticValue.Should().Be(addSeatOrderCommand.Products[0].EnergeticValue);
            order.Products[indexOfAddedOrder].Description.Should().Be(addSeatOrderCommand.Products[0].Description);
            order.Products[indexOfAddedOrder].TableNumber.Should().Be(addSeatOrderCommand.Products[0].TableNumber);
            order.Products[indexOfAddedOrder].ChairNumber.Should().Be(addSeatOrderCommand.Products[0].ChairNumber);
            order.Products[indexOfAddedOrder].Quantity.Should().Be(addSeatOrderCommand.Products[0].Quantity);

            order.Dishes[indexOfAddedOrder].Name.Should().Be(addSeatOrderCommand.Dishes[0].Name);
            order.Dishes[indexOfAddedOrder].InitialPrice.Should().Be(addSeatOrderCommand.Dishes[0].InitialPrice);
            order.Dishes[indexOfAddedOrder].UnitPrice.Should().Be(1506);
            order.Dishes[indexOfAddedOrder].EnergeticValue.Should().Be(1100);
            order.Dishes[indexOfAddedOrder].Description.Should().Be(addSeatOrderCommand.Dishes[0].Description);
            order.Dishes[indexOfAddedOrder].EstimatedPreparationTime.Should().Be(addSeatOrderCommand.Dishes[0].EstimatedPreparationTime);
            order.Dishes[indexOfAddedOrder].TableNumber.Should().Be(addSeatOrderCommand.Dishes[0].TableNumber);
            order.Dishes[indexOfAddedOrder].ChairNumber.Should().Be(addSeatOrderCommand.Dishes[0].ChairNumber);
            order.Dishes[indexOfAddedOrder].Quantity.Should().Be(addSeatOrderCommand.Dishes[0].Quantity);

            order.Dishes[indexOfAddedOrder].Specifications[0].Title.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].Title);
            order.Dishes[indexOfAddedOrder].Specifications[0].ContentType.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].ContentType);
            order.Dishes[indexOfAddedOrder].Specifications[0].ComboBoxContent.Should().BeNull();
            order.Dishes[indexOfAddedOrder].Specifications[0].ComboBoxSelection.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].ComboBoxSelection); ; ; ; ; ; ; ;
            order.Dishes[indexOfAddedOrder].Specifications[0].CheckBoxContent.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].CheckBoxContent);
            order.Dishes[indexOfAddedOrder].Specifications[0].CheckBoxSelection.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].CheckBoxSelection);
            order.Dishes[indexOfAddedOrder].Specifications[1].Title.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].Title);
            order.Dishes[indexOfAddedOrder].Specifications[1].ContentType.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ContentType);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContent.Should().Be(string.Join(";", addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContent));
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxSelection.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxSelection);
            order.Dishes[indexOfAddedOrder].Specifications[1].CheckBoxContent.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].CheckBoxContent);
            order.Dishes[indexOfAddedOrder].Specifications[1].CheckBoxSelection.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].CheckBoxSelection);

            order.Dishes[indexOfAddedOrder].Ingredients[0].IsPrimary.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].IsPrimary);
            order.Dishes[indexOfAddedOrder].Ingredients[0].Amount.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].Amount);
            order.Dishes[indexOfAddedOrder].Ingredients[0].MinimumAmount.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].MinimumAmount);
            order.Dishes[indexOfAddedOrder].Ingredients[0].MaximumAmount.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].MaximumAmount);
            order.Dishes[indexOfAddedOrder].Ingredients[0].AmountIncreasePerStep.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            order.Dishes[indexOfAddedOrder].Ingredients[0].PriceIncreasePerStep.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            order.Dishes[indexOfAddedOrder].Ingredients[0].Steps.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].Steps);
            order.Dishes[indexOfAddedOrder].Ingredients[0].MeasurementUnits.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].MeasurementUnits);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.IngredientId.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.Names.Should().Be(JsonConvert.SerializeObject(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names));
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.Fat.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.Protein.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.Energy.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.Amount.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            order.Dishes[indexOfAddedOrder].Supplements[0].SupplementId.Should().Be(addSeatOrderCommand.Dishes[0].Supplements[0].SupplementId);
            order.Dishes[indexOfAddedOrder].Supplements[0].Name.Should().Be(addSeatOrderCommand.Dishes[0].Supplements[0].Name);
            order.Dishes[indexOfAddedOrder].Supplements[0].Price.Should().Be(addSeatOrderCommand.Dishes[0].Supplements[0].Price);
            order.Dishes[indexOfAddedOrder].Supplements[0].EnergeticValue.Should().Be(addSeatOrderCommand.Dishes[0].Supplements[0].EnergeticValue);
            order.Dishes[indexOfAddedOrder].Supplements[0].Description.Should().Be(addSeatOrderCommand.Dishes[0].Supplements[0].Description);
            order.Dishes[indexOfAddedOrder].Supplements[0].IsSelected.Should().Be(addSeatOrderCommand.Dishes[0].Supplements[0].IsSelected);

            order.CommissionConfigs.Value.Should().Be(0);
            order.CommissionConfigs.Type.Should().Be(CommissionType.PerPerson);
            order.CommissionConfigs.WhoPay.Should().Be(WhoPayCommission.FoodBusiness);

        }
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

        private async Task<AddSeatOrderToTableOrderCommand> AddSeatOrderToTableOrder(string orderId,string tabelId,int chairNumber)
        {
            var addSeatOrderCommand = new AddSeatOrderToTableOrderCommand
            {
                Id = orderId,
                TableId = tabelId,
                ChairNumber = chairNumber,

                Dishes = new List<OrderDishCommandDto>() {
                new OrderDishCommandDto {
                    DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1eff",
                    Name =  "Special dish",
                    InitialPrice =  1500,
                    EnergeticValue =  800,
                    Description =  "test desc",
                    EstimatedPreparationTime =  20,
                    TableNumber =  5,
                    ChairNumber =  2,
                    Quantity =  1,
                    Specifications = new List<OrderDishSpecificationDto>() { CheckBoxModified, ComboBoxModified },
                    Ingredients =  new List<OrderDishIngredientDto>() { IngredientModified },
                    Supplements = new List<OrderDishSupplementDto>() { SupplementModified },
                    }
                },
                Products = new List<OrderProductDto>() {
                new OrderProductDto {
                    ProductId =  "7d0bf292-b9bf-404c-a50f-99c9631b3e33",
                    Name =  "Cocacola 0.25L",
                    UnitPrice =  70,
                    EnergeticValue =  90,
                    Description =  "test desc",
                    TableNumber =  5,
                    ChairNumber =  3,
                    Quantity =  3
                    }
                }
            };
            await SendAsync(addSeatOrderCommand);
            return addSeatOrderCommand;
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
