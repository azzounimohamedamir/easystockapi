using System;
using System.Collections.Generic;
using AutoMapper;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class OrderMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public OrderMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }
        OrderDishSpecificationDto CheckBox = new OrderDishSpecificationDto() {
            Title = "Spicy",
            ContentType = ContentType.CheckBox ,
            CheckBoxContent = true,
            ComboBoxContent = null,
            CheckBoxSelection = false,
            ComboBoxSelection = null
        };

        OrderDishSpecificationDto ComboBox = new OrderDishSpecificationDto()
        {
            Title = "Cuisson",
            ContentType = ContentType.ComboBox,
            CheckBoxContent = true,
            ComboBoxContent = new List<string>() { "Bien Cuite","Demi cuisson" },
            CheckBoxSelection = false,
            ComboBoxSelection = "Demi cuisson"
        };

        OrderDishIngredientDto Ingredient = new OrderDishIngredientDto()
        {
            IsPrimary = true,
            Amount = 10,
            MinimumAmount = 5,
            MaximumAmount = 25,
            AmountIncreasePerStep = 1,
            PriceIncreasePerStep = 1,
            MeasurementUnits = MeasurementUnits.Gramme,
            Steps = 0,
            OrderIngredient =  new OrderIngredientDto() {
                IngredientId =  "72867405-75a6-44bc-ac82-407ea918c8dc",
                Names =  "[{\"name\" = \"Cooking oil\",\"language\" = \"en\"},{\"name\" = \"زيت الطهي\",\"language\" = \"ar\"},{\"name\" = \"Huile\",\"language\" = \"fr\"}]",
                EnergeticValue =  new EnergeticValueDto {
                    Fat =  0,
                    Protein =  0,
                    Carbohydrates =  0,
                    Energy =  0,
                    Amount =  1,
                    MeasurementUnit =  MeasurementUnits.Gramme
                }
            }
        };

        OrderDishSupplementDto Supplement = new OrderDishSupplementDto()
        {
            SupplementId =  "e66f88b3-f39a-4301-97f0-471ad7f07e62",
            Name =  "French Fries",
            Price =  120,
            EnergeticValue =  0,
            Description =  "TEST",
            IsSelected =  true
        };




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
                Names = "[{\"name\" = \"Cooking oil Modified\",\"language\" = \"en\"},{\"name\" = \"زيت الطهي\",\"language\" = \"ar\"},{\"name\" = \"Huile\",\"language\" = \"fr\"}]",
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

        [Fact]
    public void Map_CreateOrderCommand_To_Order_Valide_Test()
    {
        var createOrderCommand = new CreateOrderCommand
        {
            Type = OrderTypes.DineIn,
            FoodBusinessId = "3cbf3570-4444-4673-8746-29b7cf568093",
            OccupiedTables = new List<OrderOccupiedTableDto>() {
                new OrderOccupiedTableDto { TableId = "44aecd78-59bb-7504-bfff-07c07129ab00" }
            },
            Dishes = new List<OrderDishDto>() {
                    new OrderDishDto {
                    DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1e6f",
                    Name =  "Rice",
                    UnitPrice =  200,
                    EnergeticValue =  0,
                    Description =  "",
                    EstimatedPreparationTime =  15,
                    TableNumber =  4,
                    ChairNumber =  1,
                    Quantity =  2,
                    Specifications = new List<OrderDishSpecificationDto>() { CheckBox, ComboBox },
                    Ingredients =  new List<OrderDishIngredientDto>() { Ingredient },
                    Supplements = new List<OrderDishSupplementDto>() { Supplement },
                }
            },
            Products = new List<OrderProductDto>() {
                new OrderProductDto {
                ProductId =  "7d0bf292-b9bf-404c-a50f-99c9631b3e18",
                Name =  "Hamooud 1L",
                UnitPrice =  120,
                EnergeticValue =  200,
                Description =  null,
                TableNumber =  4,
                ChairNumber =  1,
                Quantity =  1
                }
            }
        };

        var order = _mapper.Map<Order>(createOrderCommand);
        Assert.Equal(order.Type, OrderTypes.DineIn);
        Assert.Equal(order.FoodBusinessId, Guid.Parse(createOrderCommand.FoodBusinessId));

        Assert.Equal(order.OccupiedTables[0].TableId, createOrderCommand.OccupiedTables[0].TableId);

        Assert.Equal(order.Products[0].Name, createOrderCommand.Products[0].Name);
        Assert.Equal(order.Products[0].UnitPrice, createOrderCommand.Products[0].UnitPrice);
        Assert.Equal(order.Products[0].EnergeticValue, createOrderCommand.Products[0].EnergeticValue);
        Assert.Equal(order.Products[0].Description, createOrderCommand.Products[0].Description);
        Assert.Equal(order.Products[0].TableNumber, createOrderCommand.Products[0].TableNumber);
        Assert.Equal(order.Products[0].ChairNumber, createOrderCommand.Products[0].ChairNumber);
        Assert.Equal(order.Products[0].Quantity, createOrderCommand.Products[0].Quantity);

        Assert.Equal(order.Dishes[0].Name, createOrderCommand.Dishes[0].Name);
        Assert.Equal(order.Dishes[0].UnitPrice, createOrderCommand.Dishes[0].UnitPrice);
        Assert.Equal(order.Dishes[0].EnergeticValue, createOrderCommand.Dishes[0].EnergeticValue);
        Assert.Equal(order.Dishes[0].Description, createOrderCommand.Dishes[0].Description);
        Assert.Equal(order.Dishes[0].EstimatedPreparationTime, createOrderCommand.Dishes[0].EstimatedPreparationTime);
        Assert.Equal(order.Dishes[0].TableNumber, createOrderCommand.Dishes[0].TableNumber);
        Assert.Equal(order.Dishes[0].ChairNumber, createOrderCommand.Dishes[0].ChairNumber);
        Assert.Equal(order.Dishes[0].Quantity, createOrderCommand.Dishes[0].Quantity);

        Assert.Equal(order.Dishes[0].Specifications[0].Title, createOrderCommand.Dishes[0].Specifications[0].Title);
        Assert.Equal(order.Dishes[0].Specifications[0].ContentType, createOrderCommand.Dishes[0].Specifications[0].ContentType);
        Assert.Null (order.Dishes[0].Specifications[0].ComboBoxContent);
        Assert.Equal(order.Dishes[0].Specifications[0].ComboBoxSelection, createOrderCommand.Dishes[0].Specifications[0].ComboBoxSelection);
        Assert.Equal(order.Dishes[0].Specifications[0].CheckBoxContent, createOrderCommand.Dishes[0].Specifications[0].CheckBoxContent);
        Assert.Equal(order.Dishes[0].Specifications[0].CheckBoxSelection, createOrderCommand.Dishes[0].Specifications[0].CheckBoxSelection);
        Assert.Equal(order.Dishes[0].Specifications[1].Title, createOrderCommand.Dishes[0].Specifications[1].Title);
        Assert.Equal(order.Dishes[0].Specifications[1].ContentType, createOrderCommand.Dishes[0].Specifications[1].ContentType);
        Assert.Equal(order.Dishes[0].Specifications[1].ComboBoxContent, string.Join(";", createOrderCommand.Dishes[0].Specifications[1].ComboBoxContent));
        Assert.Equal(order.Dishes[0].Specifications[1].ComboBoxSelection, createOrderCommand.Dishes[0].Specifications[1].ComboBoxSelection);
        Assert.Equal(order.Dishes[0].Specifications[1].CheckBoxContent, createOrderCommand.Dishes[0].Specifications[1].CheckBoxContent);
        Assert.Equal(order.Dishes[0].Specifications[1].CheckBoxSelection, createOrderCommand.Dishes[0].Specifications[1].CheckBoxSelection);

        Assert.Equal(order.Dishes[0].Ingredients[0].IsPrimary, createOrderCommand.Dishes[0].Ingredients[0].IsPrimary);
        Assert.Equal(order.Dishes[0].Ingredients[0].Amount, createOrderCommand.Dishes[0].Ingredients[0].Amount);
        Assert.Equal(order.Dishes[0].Ingredients[0].MinimumAmount, createOrderCommand.Dishes[0].Ingredients[0].MinimumAmount);
        Assert.Equal(order.Dishes[0].Ingredients[0].MaximumAmount, createOrderCommand.Dishes[0].Ingredients[0].MaximumAmount);
        Assert.Equal(order.Dishes[0].Ingredients[0].AmountIncreasePerStep, createOrderCommand.Dishes[0].Ingredients[0].AmountIncreasePerStep);
        Assert.Equal(order.Dishes[0].Ingredients[0].PriceIncreasePerStep, createOrderCommand.Dishes[0].Ingredients[0].PriceIncreasePerStep);
        Assert.Equal(order.Dishes[0].Ingredients[0].Steps, createOrderCommand.Dishes[0].Ingredients[0].Steps);
        Assert.Equal(order.Dishes[0].Ingredients[0].MeasurementUnits, createOrderCommand.Dishes[0].Ingredients[0].MeasurementUnits);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId, createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.Names, createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat, createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein, createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates, createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy, createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount, createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit, createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

        Assert.Equal(order.Dishes[0].Supplements[0].SupplementId, createOrderCommand.Dishes[0].Supplements[0].SupplementId);
        Assert.Equal(order.Dishes[0].Supplements[0].Name, createOrderCommand.Dishes[0].Supplements[0].Name);
        Assert.Equal(order.Dishes[0].Supplements[0].Price, createOrderCommand.Dishes[0].Supplements[0].Price);
        Assert.Equal(order.Dishes[0].Supplements[0].EnergeticValue, createOrderCommand.Dishes[0].Supplements[0].EnergeticValue);
        Assert.Equal(order.Dishes[0].Supplements[0].Description, createOrderCommand.Dishes[0].Supplements[0].Description);
        Assert.Equal(order.Dishes[0].Supplements[0].IsSelected, createOrderCommand.Dishes[0].Supplements[0].IsSelected);
    }


    [Fact]
    public void Map_UpdateOrderCommand_To_Order_Valide_Test()
    {
        var createOrderCommand = new CreateOrderCommand
        {
            Type = OrderTypes.DineIn,
            FoodBusinessId = "3cbf3570-4444-4673-8746-29b7cf568093",
            OccupiedTables = new List<OrderOccupiedTableDto>() {
            new OrderOccupiedTableDto { TableId = "44aecd78-59bb-7504-bfff-07c07129ab00" }
        },
            Dishes = new List<OrderDishDto>() {
                new OrderDishDto {
                DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1e6f",
                Name =  "Rice",
                UnitPrice =  200,
                EnergeticValue =  0,
                Description =  "",
                EstimatedPreparationTime =  15,
                TableNumber =  4,
                ChairNumber =  1,
                Quantity =  2,
                Specifications = new List<OrderDishSpecificationDto>() { CheckBox, ComboBox },
                Ingredients =  new List<OrderDishIngredientDto>() { Ingredient },
                Supplements = new List<OrderDishSupplementDto>() { Supplement },
            }
        },
            Products = new List<OrderProductDto>() {
            new OrderProductDto {
            ProductId =  "7d0bf292-b9bf-404c-a50f-99c9631b3e18",
            Name =  "Hamooud 1L",
            UnitPrice =  120,
            EnergeticValue =  200,
            Description =  null,
            TableNumber =  4,
            ChairNumber =  1,
            Quantity =  1
            }
        }
        };
        var order = _mapper.Map<Order>(createOrderCommand);

        var updateOrderCommand = new UpdateOrderCommand
        {
            Type = OrderTypes.DineIn,
            OccupiedTables = new List<OrderOccupiedTableDto>() {
                new OrderOccupiedTableDto { TableId = "44aecd78-59bb-7504-bfff-07c07129ab20" }
            },
            Dishes = new List<OrderDishDto>() {
                new OrderDishDto {
                    DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1eff",
                    Name =  "Special dish",
                    UnitPrice =  1500,
                    EnergeticValue =  500,
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




            _mapper.Map(updateOrderCommand, order);

            Assert.Equal(order.Type, updateOrderCommand.Type);
        Assert.Equal(order.FoodBusinessId, Guid.Parse(createOrderCommand.FoodBusinessId));

        Assert.Equal(order.OccupiedTables[0].TableId, updateOrderCommand.OccupiedTables[0].TableId);

        Assert.Equal(order.Products[0].Name, updateOrderCommand.Products[0].Name);
        Assert.Equal(order.Products[0].UnitPrice, updateOrderCommand.Products[0].UnitPrice);
        Assert.Equal(order.Products[0].EnergeticValue, updateOrderCommand.Products[0].EnergeticValue);
        Assert.Equal(order.Products[0].Description, updateOrderCommand.Products[0].Description);
        Assert.Equal(order.Products[0].TableNumber, updateOrderCommand.Products[0].TableNumber);
        Assert.Equal(order.Products[0].ChairNumber, updateOrderCommand.Products[0].ChairNumber);
        Assert.Equal(order.Products[0].Quantity, updateOrderCommand.Products[0].Quantity);

        Assert.Equal(order.Dishes[0].Name, updateOrderCommand.Dishes[0].Name);
        Assert.Equal(order.Dishes[0].UnitPrice, updateOrderCommand.Dishes[0].UnitPrice);
        Assert.Equal(order.Dishes[0].EnergeticValue, updateOrderCommand.Dishes[0].EnergeticValue);
        Assert.Equal(order.Dishes[0].Description, updateOrderCommand.Dishes[0].Description);
        Assert.Equal(order.Dishes[0].EstimatedPreparationTime, updateOrderCommand.Dishes[0].EstimatedPreparationTime);
        Assert.Equal(order.Dishes[0].TableNumber, updateOrderCommand.Dishes[0].TableNumber);
        Assert.Equal(order.Dishes[0].ChairNumber, updateOrderCommand.Dishes[0].ChairNumber);
        Assert.Equal(order.Dishes[0].Quantity, updateOrderCommand.Dishes[0].Quantity);

        Assert.Equal(order.Dishes[0].Specifications[0].Title, updateOrderCommand.Dishes[0].Specifications[0].Title);
        Assert.Equal(order.Dishes[0].Specifications[0].ContentType, updateOrderCommand.Dishes[0].Specifications[0].ContentType);
        Assert.Null(order.Dishes[0].Specifications[0].ComboBoxContent);
        Assert.Equal(order.Dishes[0].Specifications[0].ComboBoxSelection, updateOrderCommand.Dishes[0].Specifications[0].ComboBoxSelection);
        Assert.Equal(order.Dishes[0].Specifications[0].CheckBoxContent, updateOrderCommand.Dishes[0].Specifications[0].CheckBoxContent);
        Assert.Equal(order.Dishes[0].Specifications[0].CheckBoxSelection, updateOrderCommand.Dishes[0].Specifications[0].CheckBoxSelection);
        Assert.Equal(order.Dishes[0].Specifications[1].Title, updateOrderCommand.Dishes[0].Specifications[1].Title);
        Assert.Equal(order.Dishes[0].Specifications[1].ContentType, updateOrderCommand.Dishes[0].Specifications[1].ContentType);
        Assert.Equal(order.Dishes[0].Specifications[1].ComboBoxContent, string.Join(";", updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContent));
        Assert.Equal(order.Dishes[0].Specifications[1].ComboBoxSelection, updateOrderCommand.Dishes[0].Specifications[1].ComboBoxSelection);
        Assert.Equal(order.Dishes[0].Specifications[1].CheckBoxContent, updateOrderCommand.Dishes[0].Specifications[1].CheckBoxContent);
        Assert.Equal(order.Dishes[0].Specifications[1].CheckBoxSelection, updateOrderCommand.Dishes[0].Specifications[1].CheckBoxSelection);

        Assert.Equal(order.Dishes[0].Ingredients[0].IsPrimary, updateOrderCommand.Dishes[0].Ingredients[0].IsPrimary);
        Assert.Equal(order.Dishes[0].Ingredients[0].Amount, updateOrderCommand.Dishes[0].Ingredients[0].Amount);
        Assert.Equal(order.Dishes[0].Ingredients[0].MinimumAmount, updateOrderCommand.Dishes[0].Ingredients[0].MinimumAmount);
        Assert.Equal(order.Dishes[0].Ingredients[0].MaximumAmount, updateOrderCommand.Dishes[0].Ingredients[0].MaximumAmount);
        Assert.Equal(order.Dishes[0].Ingredients[0].AmountIncreasePerStep, updateOrderCommand.Dishes[0].Ingredients[0].AmountIncreasePerStep);
        Assert.Equal(order.Dishes[0].Ingredients[0].PriceIncreasePerStep, updateOrderCommand.Dishes[0].Ingredients[0].PriceIncreasePerStep);
        Assert.Equal(order.Dishes[0].Ingredients[0].Steps, updateOrderCommand.Dishes[0].Ingredients[0].Steps);
        Assert.Equal(order.Dishes[0].Ingredients[0].MeasurementUnits, updateOrderCommand.Dishes[0].Ingredients[0].MeasurementUnits);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId, updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.Names, updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat, updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein, updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates, updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy, updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount, updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit, updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

        Assert.Equal(order.Dishes[0].Supplements[0].SupplementId, updateOrderCommand.Dishes[0].Supplements[0].SupplementId);
        Assert.Equal(order.Dishes[0].Supplements[0].Name, updateOrderCommand.Dishes[0].Supplements[0].Name);
        Assert.Equal(order.Dishes[0].Supplements[0].Price, updateOrderCommand.Dishes[0].Supplements[0].Price);
        Assert.Equal(order.Dishes[0].Supplements[0].EnergeticValue, updateOrderCommand.Dishes[0].Supplements[0].EnergeticValue);
        Assert.Equal(order.Dishes[0].Supplements[0].Description, updateOrderCommand.Dishes[0].Supplements[0].Description);
        Assert.Equal(order.Dishes[0].Supplements[0].IsSelected, updateOrderCommand.Dishes[0].Supplements[0].IsSelected);
    }


    }
}