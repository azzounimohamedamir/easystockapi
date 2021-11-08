using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class OrderTestTools
    {
        public static async Task<CreateOrderCommand> CreateOrder(Guid foodBusinessId)
        {
            OrderDishSpecificationDto CheckBox = new OrderDishSpecificationDto()
            {
                Title = "Spicy",
                ContentType = 0,
                CheckBoxContent = true,
                ComboBoxContent = null,
                CheckBoxSelection = false,
                ComboBoxSelection = null
            };

            OrderDishSpecificationDto ComboBox = new OrderDishSpecificationDto()
            {
                Title = "Cuisson",
                ContentType = 0,
                CheckBoxContent = true,
                ComboBoxContent = new List<string>() { "Bien Cuite", "Demi cuisson" },
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
                OrderIngredient = new OrderIngredientDto()
                {
                    IngredientId = "72867405-75a6-44bc-ac82-407ea918c8dc",
                    Names = "[{\"name\" = \"Cooking oil\",\"language\" = \"en\"},{\"name\" = \"زيت الطهي\",\"language\" = \"ar\"},{\"name\" = \"Huile\",\"language\" = \"fr\"}]",
                    EnergeticValue = new EnergeticValueDto
                    {
                        Fat = 0,
                        Protein = 0,
                        Carbohydrates = 0,
                        Energy = 0,
                        Amount = 1,
                        MeasurementUnit = MeasurementUnits.Gramme
                    }
                }
            };

            OrderDishSupplementDto Supplement = new OrderDishSupplementDto()
            {
                SupplementId = "e66f88b3-f39a-4301-97f0-471ad7f07e62",
                Name = "French Fries",
                Price = 120,
                EnergeticValue = 0,
                Description = "TEST",
                IsSelected = true
            };

            var createOrderCommand = new CreateOrderCommand
            {
                Type = OrderTypes.DineIn,
                FoodBusinessId = foodBusinessId.ToString(),
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

            await SendAsync(createOrderCommand);

            return createOrderCommand;
        }

   }
}
