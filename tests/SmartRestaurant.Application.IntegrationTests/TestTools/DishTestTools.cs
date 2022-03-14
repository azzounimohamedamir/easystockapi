using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class DishTestTools
    {
        public static async Task<CreateDishCommand> CreateDish(Guid foodBusinessId, Guid ingredientId)
        {
            var createDishSupplement = new CreateDishCommand
            {
                Name = "Supplement",
                Description = "Supplement description",
                Picture = Properties.Resources.PictureBase64_02,
                Price = 100,
                FoodBusinessId = foodBusinessId.ToString(),
                IsSupplement = true,
                EstimatedPreparationTime = 600
            };
            await SendAsync(createDishSupplement);

            var createDishCommand = new CreateDishCommand
            {
                Name = "Fakhitasse",
                Description = "Fakhitasse description",
                Picture = Properties.Resources.PictureBase64_01,
                Price = 280,
                FoodBusinessId = foodBusinessId.ToString(),
                Specifications = new List<DishSpecificationDto>() {
                    new  DishSpecificationDto()   {ContentType =  ContentType.CheckBox, Title = "Slaty", CheckBoxContent = false},
                    new  DishSpecificationDto()   {ContentType = ContentType.ComboBox,  Title = "Cuission", ComboBoxContent = new List<string>() {"Bien Cuite", "Demi cuisson" } }
                },
                Ingredients = new List<DishIngredientCreateDto>() {
                    new  DishIngredientCreateDto()   {
                        InitialAmount = 20,
                        MinimumAmount = 10,
                        MaximumAmount = 50,
                        MeasurementUnits = MeasurementUnits.KiloGramme,
                        AmountIncreasePerStep = 10,
                        PriceIncreasePerStep = 20,
                        IngredientId = ingredientId.ToString()
                    },
                },
                Supplements = new List<DishSupplementCreateDto>() {
                    new  DishSupplementCreateDto()   {SupplementId =  createDishSupplement.Id.ToString()},
                },
                IsSupplement = false,
                EstimatedPreparationTime = 1200
            };
            await SendAsync(createDishCommand);

            return createDishCommand;
        }

   }
}
