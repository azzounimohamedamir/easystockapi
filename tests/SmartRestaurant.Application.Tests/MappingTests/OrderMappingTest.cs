using System;
using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
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
                Names = new List<IngredientNameDto>{ 
                    new IngredientNameDto() {Name = "Cooking oil",Language = "en"},
                    new IngredientNameDto() {Name = "زيت الطهي",Language = "ar"},
                    new IngredientNameDto() {Name = "Huile",Language = "fr"}
                    },
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
            Dishes = new List<OrderDishCommandDto>() {
                    new OrderDishCommandDto {
                    DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1e6f",
                    Name =  "Rice",
                    InitialPrice =  200,
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
        Assert.Null(order.FoodBusinessClientId);
        Assert.Equal(order.OccupiedTables[0].TableId, createOrderCommand.OccupiedTables[0].TableId);

        Assert.Equal(order.Products[0].Name, createOrderCommand.Products[0].Name);
        Assert.Equal(order.Products[0].UnitPrice, createOrderCommand.Products[0].UnitPrice);
        Assert.Equal(order.Products[0].EnergeticValue, createOrderCommand.Products[0].EnergeticValue);
        Assert.Equal(order.Products[0].Description, createOrderCommand.Products[0].Description);
        Assert.Equal(order.Products[0].TableNumber, createOrderCommand.Products[0].TableNumber);
        Assert.Equal(order.Products[0].ChairNumber, createOrderCommand.Products[0].ChairNumber);
        Assert.Equal(order.Products[0].Quantity, createOrderCommand.Products[0].Quantity);

        Assert.Equal(order.Dishes[0].Name, createOrderCommand.Dishes[0].Name);
        Assert.Equal(order.Dishes[0].InitialPrice, createOrderCommand.Dishes[0].InitialPrice);
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
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.Names, JsonConvert.SerializeObject(createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names));
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
                FoodBusinessClientId = null,
            OccupiedTables = new List<OrderOccupiedTableDto>() {
            new OrderOccupiedTableDto { TableId = "44aecd78-59bb-7504-bfff-07c07129ab00" }
        },
            Dishes = new List<OrderDishCommandDto>() {
                new OrderDishCommandDto {
                DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1e6f",
                Name =  "Rice",
                InitialPrice =  200,
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
            FoodBusinessClientId = "ccffcd45-59bb-75ab-b3cf-07b3cf29ab33",
            Type = OrderTypes.DineIn,
            OccupiedTables = new List<OrderOccupiedTableDto>() {
                new OrderOccupiedTableDto { TableId = "44aecd78-59bb-7504-bfff-07c07129ab20" }
            },
            Dishes = new List<OrderDishCommandDto>() {
                new OrderDishCommandDto {
                    DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1eff",
                    Name =  "Special dish",
                    InitialPrice =  1500,
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
        Assert.NotNull(order.FoodBusinessClientId);

        Assert.Equal(order.OccupiedTables[0].TableId, updateOrderCommand.OccupiedTables[0].TableId);
        Assert.Equal(order.FoodBusinessClientId, Guid.Parse(updateOrderCommand.FoodBusinessClientId));

        Assert.Equal(order.Products[0].Name, updateOrderCommand.Products[0].Name);
        Assert.Equal(order.Products[0].UnitPrice, updateOrderCommand.Products[0].UnitPrice);
        Assert.Equal(order.Products[0].EnergeticValue, updateOrderCommand.Products[0].EnergeticValue);
        Assert.Equal(order.Products[0].Description, updateOrderCommand.Products[0].Description);
        Assert.Equal(order.Products[0].TableNumber, updateOrderCommand.Products[0].TableNumber);
        Assert.Equal(order.Products[0].ChairNumber, updateOrderCommand.Products[0].ChairNumber);
        Assert.Equal(order.Products[0].Quantity, updateOrderCommand.Products[0].Quantity);

        Assert.Equal(order.Dishes[0].Name, updateOrderCommand.Dishes[0].Name);
        Assert.Equal(order.Dishes[0].InitialPrice, updateOrderCommand.Dishes[0].InitialPrice);
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
        Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.Names, JsonConvert.SerializeObject(updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names));
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


    [Fact]
    public void Map_UpdateOrderStatusCommand_To_Order_Valide_Test()
    {
        var createOrderCommand = new CreateOrderCommand
        {
            Type = OrderTypes.DineIn,
            FoodBusinessId = "3cbf3570-4444-4673-8746-29b7cf568093",
            OccupiedTables = new List<OrderOccupiedTableDto>() {
        new OrderOccupiedTableDto { TableId = "44aecd78-59bb-7504-bfff-07c07129ab00" }
    },
            Dishes = new List<OrderDishCommandDto>() {
            new OrderDishCommandDto {
            DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1e6f",
            Name =  "Rice",
            InitialPrice =  200,
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
        var updateOrderStatusCommand = new UpdateOrderStatusCommand
        {
          Status = OrderStatuses.Cancelled
        };


        Assert.Equal(order.Status, OrderStatuses.InQueue);
        _mapper.Map(updateOrderStatusCommand, order);
        Assert.Equal(order.Status, OrderStatuses.Cancelled);       
    }


        [Fact]
        public void Map_Order_To_OrderDto_Valide_Test()
        {
            var order = _mapper.Map<Order>(new CreateOrderCommand
            {
                Type = OrderTypes.DineIn,
                FoodBusinessId = "3cbf3570-4444-4673-8746-29b7cf568093",
                TakeoutDetails = new TakeoutDetailsDto()
                {
                    DeliveryTime = DateTime.Now,
                    Type = TakeoutType.Delayed
                },
                OccupiedTables = new List<OrderOccupiedTableDto>() {
                    new OrderOccupiedTableDto { TableId = "44aecd78-59bb-7504-bfff-07c07129ab00" }
                },
                Dishes = new List<OrderDishCommandDto>() {
                    new OrderDishCommandDto {
                        DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1e6f",
                        Name =  "Rice",
                        InitialPrice = 200,
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
            }); ;
            order.CreatedAt = DateTime.Now;

            var orderDto = _mapper.Map<OrderDto>(order);

            Assert.Equal(orderDto.Type, order.Type);
            Assert.Equal(orderDto.Status, order.Status);
            Assert.Equal(orderDto.FoodBusinessId, order.FoodBusinessId);
            Assert.Equal(orderDto.CreatedAt, order.CreatedAt);
            Assert.Equal(orderDto.TotalToPay, order.TotalToPay);
            Assert.Equal(orderDto.MoneyReceived, order.MoneyReceived);
            Assert.Equal(orderDto.MoneyReturned, order.MoneyReturned);
            Assert.Equal(orderDto.Number, order.Number);
            Assert.Equal(orderDto.OrderId, order.OrderId);
            Assert.Equal(orderDto.TakeoutDetails.Type, order.TakeoutDetails.Type);
            Assert.Equal(orderDto.TakeoutDetails.DeliveryTime, order.TakeoutDetails.DeliveryTime);

            Assert.Equal(orderDto.OccupiedTables[0].TableId, order.OccupiedTables[0].TableId);

            Assert.Equal(orderDto.Products[0].Name, order.Products[0].Name);
            Assert.Equal(orderDto.Products[0].UnitPrice, order.Products[0].UnitPrice);
            Assert.Equal(orderDto.Products[0].EnergeticValue, order.Products[0].EnergeticValue);
            Assert.Equal(orderDto.Products[0].Description, order.Products[0].Description);
            Assert.Equal(orderDto.Products[0].TableNumber, order.Products[0].TableNumber);
            Assert.Equal(orderDto.Products[0].ChairNumber, order.Products[0].ChairNumber);
            Assert.Equal(orderDto.Products[0].Quantity, order.Products[0].Quantity);

            Assert.Equal(orderDto.Dishes[0].Name, order.Dishes[0].Name);
            Assert.Equal(orderDto.Dishes[0].InitialPrice, order.Dishes[0].InitialPrice);
            Assert.Equal(orderDto.Dishes[0].UnitPrice, order.Dishes[0].UnitPrice);
            Assert.Equal(orderDto.Dishes[0].EnergeticValue, order.Dishes[0].EnergeticValue);
            Assert.Equal(orderDto.Dishes[0].Description, order.Dishes[0].Description);
            Assert.Equal(orderDto.Dishes[0].EstimatedPreparationTime, order.Dishes[0].EstimatedPreparationTime);
            Assert.Equal(orderDto.Dishes[0].TableNumber, order.Dishes[0].TableNumber);
            Assert.Equal(orderDto.Dishes[0].ChairNumber, order.Dishes[0].ChairNumber);
            Assert.Equal(orderDto.Dishes[0].Quantity, order.Dishes[0].Quantity);

            Assert.Equal(orderDto.Dishes[0].Specifications[0].Title, order.Dishes[0].Specifications[0].Title);
            Assert.Equal(orderDto.Dishes[0].Specifications[0].ContentType, order.Dishes[0].Specifications[0].ContentType);
            Assert.Equal(orderDto.Dishes[0].Specifications[0].ComboBoxContent, new string[0]);
            Assert.Equal(orderDto.Dishes[0].Specifications[0].ComboBoxSelection, order.Dishes[0].Specifications[0].ComboBoxSelection);
            Assert.Equal(orderDto.Dishes[0].Specifications[0].CheckBoxContent, order.Dishes[0].Specifications[0].CheckBoxContent);
            Assert.Equal(orderDto.Dishes[0].Specifications[0].CheckBoxSelection, order.Dishes[0].Specifications[0].CheckBoxSelection);
            Assert.Equal(orderDto.Dishes[0].Specifications[1].Title, order.Dishes[0].Specifications[1].Title);
            Assert.Equal(orderDto.Dishes[0].Specifications[1].ContentType, order.Dishes[0].Specifications[1].ContentType);
            Assert.Equal(orderDto.Dishes[0].Specifications[1].ComboBoxContent, order.Dishes[0].Specifications[1].ComboBoxContent.Split(';'));
            Assert.Equal(orderDto.Dishes[0].Specifications[1].ComboBoxSelection, order.Dishes[0].Specifications[1].ComboBoxSelection);
            Assert.Equal(orderDto.Dishes[0].Specifications[1].CheckBoxContent, order.Dishes[0].Specifications[1].CheckBoxContent);
            Assert.Equal(orderDto.Dishes[0].Specifications[1].CheckBoxSelection, order.Dishes[0].Specifications[1].CheckBoxSelection);

            Assert.Equal(orderDto.Dishes[0].Ingredients[0].IsPrimary, order.Dishes[0].Ingredients[0].IsPrimary);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].Amount, order.Dishes[0].Ingredients[0].Amount);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].MinimumAmount, order.Dishes[0].Ingredients[0].MinimumAmount);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].MaximumAmount, order.Dishes[0].Ingredients[0].MaximumAmount);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].AmountIncreasePerStep, order.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].PriceIncreasePerStep, order.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].Steps, order.Dishes[0].Ingredients[0].Steps);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].MeasurementUnits, order.Dishes[0].Ingredients[0].MeasurementUnits);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].OrderIngredient.IngredientId, order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            Assert.Equal(JsonConvert.SerializeObject(orderDto.Dishes[0].Ingredients[0].OrderIngredient.Names), order.Dishes[0].Ingredients[0].OrderIngredient.Names);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat, order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein, order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates, order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy, order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount, order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            Assert.Equal(orderDto.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit, order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            Assert.Equal(orderDto.Dishes[0].Supplements[0].SupplementId, order.Dishes[0].Supplements[0].SupplementId);
            Assert.Equal(orderDto.Dishes[0].Supplements[0].Name, order.Dishes[0].Supplements[0].Name);
            Assert.Equal(orderDto.Dishes[0].Supplements[0].Price, order.Dishes[0].Supplements[0].Price);
            Assert.Equal(orderDto.Dishes[0].Supplements[0].EnergeticValue, order.Dishes[0].Supplements[0].EnergeticValue);
            Assert.Equal(orderDto.Dishes[0].Supplements[0].Description, order.Dishes[0].Supplements[0].Description);
            Assert.Equal(orderDto.Dishes[0].Supplements[0].IsSelected, order.Dishes[0].Supplements[0].IsSelected);
        }
        [Fact]
        public void Map_AddSeatOrderToTableOrderCommand_To_Order_Valide_Test()
        {
            var addSeatOrderCommand = new AddSeatOrderToTableOrderCommand
            {
               
                Dishes = new List<OrderDishCommandDto>() {
                new OrderDishCommandDto {
                DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1e6f",
                Name =  "Rice",
                InitialPrice =  200,
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
            var order = _mapper.Map<Order>(addSeatOrderCommand);

            Assert.Equal(order.Products[0].Name, addSeatOrderCommand.Products[0].Name);
            Assert.Equal(order.Products[0].UnitPrice, addSeatOrderCommand.Products[0].UnitPrice);
            Assert.Equal(order.Products[0].EnergeticValue, addSeatOrderCommand.Products[0].EnergeticValue);
            Assert.Equal(order.Products[0].Description, addSeatOrderCommand.Products[0].Description);
            Assert.Equal(order.Products[0].TableNumber, addSeatOrderCommand.Products[0].TableNumber);
            Assert.Equal(order.Products[0].ChairNumber, addSeatOrderCommand.Products[0].ChairNumber);
            Assert.Equal(order.Products[0].Quantity, addSeatOrderCommand.Products[0].Quantity);

            Assert.Equal(order.Dishes[0].Name, addSeatOrderCommand.Dishes[0].Name);
            Assert.Equal(order.Dishes[0].InitialPrice, addSeatOrderCommand.Dishes[0].InitialPrice);
            Assert.Equal(order.Dishes[0].EnergeticValue, addSeatOrderCommand.Dishes[0].EnergeticValue);
            Assert.Equal(order.Dishes[0].Description, addSeatOrderCommand.Dishes[0].Description);
            Assert.Equal(order.Dishes[0].EstimatedPreparationTime, addSeatOrderCommand.Dishes[0].EstimatedPreparationTime);
            Assert.Equal(order.Dishes[0].TableNumber, addSeatOrderCommand.Dishes[0].TableNumber);
            Assert.Equal(order.Dishes[0].ChairNumber, addSeatOrderCommand.Dishes[0].ChairNumber);
            Assert.Equal(order.Dishes[0].Quantity, addSeatOrderCommand.Dishes[0].Quantity);

            Assert.Equal(order.Dishes[0].Specifications[0].Title, addSeatOrderCommand.Dishes[0].Specifications[0].Title);
            Assert.Equal(order.Dishes[0].Specifications[0].ContentType, addSeatOrderCommand.Dishes[0].Specifications[0].ContentType);
            Assert.Null(order.Dishes[0].Specifications[0].ComboBoxContent);
            Assert.Equal(order.Dishes[0].Specifications[0].ComboBoxSelection, addSeatOrderCommand.Dishes[0].Specifications[0].ComboBoxSelection);
            Assert.Equal(order.Dishes[0].Specifications[0].CheckBoxContent, addSeatOrderCommand.Dishes[0].Specifications[0].CheckBoxContent);
            Assert.Equal(order.Dishes[0].Specifications[0].CheckBoxSelection, addSeatOrderCommand.Dishes[0].Specifications[0].CheckBoxSelection);
            Assert.Equal(order.Dishes[0].Specifications[1].Title, addSeatOrderCommand.Dishes[0].Specifications[1].Title);
            Assert.Equal(order.Dishes[0].Specifications[1].ContentType, addSeatOrderCommand.Dishes[0].Specifications[1].ContentType);
            Assert.Equal(order.Dishes[0].Specifications[1].ComboBoxContent, string.Join(";", addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContent));
            Assert.Equal(order.Dishes[0].Specifications[1].ComboBoxSelection, addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxSelection);
            Assert.Equal(order.Dishes[0].Specifications[1].CheckBoxContent, addSeatOrderCommand.Dishes[0].Specifications[1].CheckBoxContent);
            Assert.Equal(order.Dishes[0].Specifications[1].CheckBoxSelection, addSeatOrderCommand.Dishes[0].Specifications[1].CheckBoxSelection);

            Assert.Equal(order.Dishes[0].Ingredients[0].IsPrimary, addSeatOrderCommand.Dishes[0].Ingredients[0].IsPrimary);
            Assert.Equal(order.Dishes[0].Ingredients[0].Amount, addSeatOrderCommand.Dishes[0].Ingredients[0].Amount);
            Assert.Equal(order.Dishes[0].Ingredients[0].MinimumAmount, addSeatOrderCommand.Dishes[0].Ingredients[0].MinimumAmount);
            Assert.Equal(order.Dishes[0].Ingredients[0].MaximumAmount, addSeatOrderCommand.Dishes[0].Ingredients[0].MaximumAmount);
            Assert.Equal(order.Dishes[0].Ingredients[0].AmountIncreasePerStep, addSeatOrderCommand.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            Assert.Equal(order.Dishes[0].Ingredients[0].PriceIncreasePerStep, addSeatOrderCommand.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            Assert.Equal(order.Dishes[0].Ingredients[0].Steps, addSeatOrderCommand.Dishes[0].Ingredients[0].Steps);
            Assert.Equal(order.Dishes[0].Ingredients[0].MeasurementUnits, addSeatOrderCommand.Dishes[0].Ingredients[0].MeasurementUnits);
            Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId, addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.Names, JsonConvert.SerializeObject(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names));
            Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat, addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein, addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates, addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy, addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount, addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            Assert.Equal(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit, addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            Assert.Equal(order.Dishes[0].Supplements[0].SupplementId, addSeatOrderCommand.Dishes[0].Supplements[0].SupplementId);
            Assert.Equal(order.Dishes[0].Supplements[0].Name, addSeatOrderCommand.Dishes[0].Supplements[0].Name);
            Assert.Equal(order.Dishes[0].Supplements[0].Price, addSeatOrderCommand.Dishes[0].Supplements[0].Price);
            Assert.Equal(order.Dishes[0].Supplements[0].EnergeticValue, addSeatOrderCommand.Dishes[0].Supplements[0].EnergeticValue);
            Assert.Equal(order.Dishes[0].Supplements[0].Description, addSeatOrderCommand.Dishes[0].Supplements[0].Description);
            Assert.Equal(order.Dishes[0].Supplements[0].IsSelected, addSeatOrderCommand.Dishes[0].Supplements[0].IsSelected);
        }

    }
}