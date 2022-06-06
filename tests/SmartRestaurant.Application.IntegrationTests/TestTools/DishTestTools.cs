using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
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
                Names = new NamesDto() { AR= "Supplement AR", EN= "Supplement EN", FR= "Supplement FR", TR= "Supplement TR", RU= "Supplement RU" },
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
                Names = new NamesDto() { AR = "Fakhitasse AR", EN = "Fakhitasse EN", FR = "Fakhitasse FR", TR = "Fakhitasse TR", RU = "Fakhitasse RU" },
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

        public static async Task<CreateDishCommand> CreateDishWithOutSuppliment(Guid foodBusinessId, Guid ingredientId)
        {

            var createDishCommand = new CreateDishCommand
            {
                Name = "Fakhitasse",
                Names = new NamesDto() { AR = "Fakhitasse AR", EN = "Fakhitasse EN", FR = "Fakhitasse FR", TR = "Fakhitasse TR", RU = "Fakhitasse RU" },
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
                IsSupplement = false,
                EstimatedPreparationTime = 1200
            };
            await SendAsync(createDishCommand);

            return createDishCommand;
        }

        public static async Task<CreateDishCommand> CreateDishWithSupplimentIngredient(Guid foodBusinessId, Guid ingredientId, Guid ingredientId2)
        {
            var createDishSupplement = new CreateDishCommand
            {
                Name = "Supplement",
                Names = new NamesDto() { AR = "Supplement AR", EN = "Supplement EN", FR = "Supplement FR", TR = "Supplement TR", RU = "Supplement RU" },
                Description = "Supplement description",
                Picture = Properties.Resources.PictureBase64_02,
                Price = 100,
                FoodBusinessId = foodBusinessId.ToString(),
                IsSupplement = true,
                EstimatedPreparationTime = 600,
                Ingredients = new List<DishIngredientCreateDto>() {
                    new  DishIngredientCreateDto()   {
                        InitialAmount = 20,
                        MinimumAmount = 10,
                        MaximumAmount = 50,
                        MeasurementUnits = MeasurementUnits.KiloGramme,
                        AmountIncreasePerStep = 10,
                        PriceIncreasePerStep = 20,
                        IngredientId = ingredientId2.ToString()
                    },
                }
            };
            await SendAsync(createDishSupplement);

            var createDishCommand = new CreateDishCommand
            {
                Name = "Fakhitasse",
                Names = new NamesDto() { AR = "Fakhitasse AR", EN = "Fakhitasse EN", FR = "Fakhitasse FR", TR = "Fakhitasse TR", RU = "Fakhitasse RU" },
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
