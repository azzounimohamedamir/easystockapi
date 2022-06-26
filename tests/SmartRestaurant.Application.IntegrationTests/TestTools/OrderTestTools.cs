using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class OrderTestTools
    {
        public static async Task<CreateOrderCommand> CreateOrder(Guid foodBusinessId, 
            string? foodBusinessClientId, 
            CreateDishCommand dishCommand, 
            CreateProductCommand procuctCommand)
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
                    IngredientId = dishCommand.Ingredients[0].IngredientId,
                    Names = new List<IngredientNameDto>{
                    new IngredientNameDto() {Name = "Cooking oil Modified",Language = "en"},
                    new IngredientNameDto() {Name = "Modified زيت الطهي",Language = "ar"},
                    new IngredientNameDto() {Name = "Huile Modified",Language = "fr"}
                    },
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
                SupplementId = dishCommand.Supplements[0].SupplementId,
                IsSelected = true
            };

            var createOrderCommand = new CreateOrderCommand
            {
                Type = OrderTypes.DineIn,
                FoodBusinessId = foodBusinessId.ToString(),
                FoodBusinessClientId = foodBusinessClientId,
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
                      DishId =dishCommand.Id.ToString(),
                      EnergeticValue =  0,
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
                    ProductId =procuctCommand.Id.ToString(),
                    TableNumber =  4,
                    ChairNumber =  1,
                    Quantity =  1
                }
            }
            };

            await SendAsync(createOrderCommand);

            return createOrderCommand;
        }
        public static  async Task<UpdateOrderStatusCommand> UpdateOrderStatus(CreateOrderCommand createOrderCommand)
        {
            var updateStatusOrderCommand = new UpdateOrderStatusCommand
            {
                Id = createOrderCommand.Id.ToString(),
                Status = OrderStatuses.Cancelled
            };
            await SendAsync(updateStatusOrderCommand);
            return updateStatusOrderCommand;
        }

    }
}
