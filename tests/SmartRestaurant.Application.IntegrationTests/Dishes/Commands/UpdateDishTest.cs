using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Dishes.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateDishTest : TestBase
    {   
        [Test]
        public async Task UpdateDish_ShouldSaveToDB()
        {

            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var dish = await GetDish(createDishCommand.Id);

            var updateDishCommand = await UpdateDish(dish, createIngredientCommand.Id, fastFood.FoodBusinessId);
            var updatedDish = await GetDish(Guid.Parse(updateDishCommand.Id));


            updatedDish.Should().NotBeNull();
            updatedDish.DishId.Should().Be(updateDishCommand.Id);
            updatedDish.Name.Should().Be(updateDishCommand.Name);

            updatedDish.Names.AR.Should().Be(updateDishCommand.Names.AR);
            updatedDish.Names.EN.Should().Be(updateDishCommand.Names.EN);
            updatedDish.Names.FR.Should().Be(updateDishCommand.Names.FR);
            updatedDish.Names.TR.Should().Be(updateDishCommand.Names.TR);
            updatedDish.Names.RU.Should().Be(updateDishCommand.Names.RU);

            updatedDish.Price.Should().Be(updateDishCommand.Price);
            updatedDish.FoodBusinessId.Should().Be(dish.FoodBusinessId);
            updatedDish.IsSupplement.Should().Be(updateDishCommand.IsSupplement);
            updatedDish.EstimatedPreparationTime.Should().Be(updateDishCommand.EstimatedPreparationTime);
            updatedDish.Picture.Should().BeEquivalentTo(Convert.FromBase64String(updateDishCommand.Picture));
            updatedDish.CreatedBy.Should().NotBeNull();
            updatedDish.CreatedAt.Should().NotBe(default);
            updatedDish.LastModifiedBy.Should().Be(_authenticatedUserId);
            updatedDish.LastModifiedAt.Should().NotBe(default);

            updatedDish.Specifications.Should().HaveCount(2);
            updatedDish.Specifications[0].Title.Should().Be(updateDishCommand.Specifications[0].Title);

            updatedDish.Specifications[0].Names.AR.Should().Be(updateDishCommand.Specifications[0].Names.AR);
            updatedDish.Specifications[0].Names.EN.Should().Be(updateDishCommand.Specifications[0].Names.EN);
            updatedDish.Specifications[0].Names.FR.Should().Be(updateDishCommand.Specifications[0].Names.FR);
            updatedDish.Specifications[0].Names.TR.Should().Be(updateDishCommand.Specifications[0].Names.TR);
            updatedDish.Specifications[0].Names.RU.Should().Be(updateDishCommand.Specifications[0].Names.RU);

            updatedDish.Specifications[0].ContentType.Should().Be(updateDishCommand.Specifications[0].ContentType);
            updatedDish.Specifications[0].CheckBoxContent.Should().Be(updateDishCommand.Specifications[0].CheckBoxContent);
            updatedDish.Specifications[0].ComboBoxContent.Should().BeNull();
            updatedDish.Specifications[1].Title.Should().Be(updateDishCommand.Specifications[1].Title);
            updatedDish.Specifications[1].ContentType.Should().Be(updateDishCommand.Specifications[1].ContentType);
            updatedDish.Specifications[1].CheckBoxContent.Should().Be(updateDishCommand.Specifications[1].CheckBoxContent);

            updatedDish.Specifications[1].ComboBoxContentTranslation[0].Name.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[0].Name);
            updatedDish.Specifications[1].ComboBoxContentTranslation[0].Names.AR.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[0].Names.AR);
            updatedDish.Specifications[1].ComboBoxContentTranslation[0].Names.EN.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[0].Names.EN);
            updatedDish.Specifications[1].ComboBoxContentTranslation[0].Names.FR.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[0].Names.FR);
            updatedDish.Specifications[1].ComboBoxContentTranslation[0].Names.TR.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[0].Names.TR);
            updatedDish.Specifications[1].ComboBoxContentTranslation[0].Names.RU.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[0].Names.RU);

            updatedDish.Specifications[1].ComboBoxContentTranslation[1].Name.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[1].Name);
            updatedDish.Specifications[1].ComboBoxContentTranslation[1].Names.AR.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[1].Names.AR);
            updatedDish.Specifications[1].ComboBoxContentTranslation[1].Names.EN.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[1].Names.EN);
            updatedDish.Specifications[1].ComboBoxContentTranslation[1].Names.FR.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[1].Names.FR);
            updatedDish.Specifications[1].ComboBoxContentTranslation[1].Names.TR.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[1].Names.TR);
            updatedDish.Specifications[1].ComboBoxContentTranslation[1].Names.RU.Should().Be(updateDishCommand.Specifications[1].ComboBoxContentTranslation[1].Names.RU);

            updatedDish.Ingredients.Should().HaveCount(1);
            updatedDish.Ingredients[0].InitialAmount.Should().Be(updateDishCommand.Ingredients[0].InitialAmount);
            updatedDish.Ingredients[0].MinimumAmount.Should().Be(updateDishCommand.Ingredients[0].MinimumAmount);
            updatedDish.Ingredients[0].MaximumAmount.Should().Be(updateDishCommand.Ingredients[0].MaximumAmount);
            updatedDish.Ingredients[0].AmountIncreasePerStep.Should().Be(updateDishCommand.Ingredients[0].AmountIncreasePerStep);
            updatedDish.Ingredients[0].PriceIncreasePerStep.Should().Be(updateDishCommand.Ingredients[0].PriceIncreasePerStep);
            updatedDish.Ingredients[0].Ingredient.IngredientId.Should().Be(Guid.Parse(updateDishCommand.Ingredients[0].IngredientId));
            
            updatedDish.Supplements.Should().HaveCount(1);
            updatedDish.Supplements[0].Supplement.DishId.Should().Be(Guid.Parse(updateDishCommand.Supplements[0].SupplementId));

            var suppliment = await GetDish(Guid.Parse(updateDishCommand.Supplements[0].SupplementId));

            updatedDish.Supplements[0].Supplement.Name.Should().Be(suppliment.Name);

            updatedDish.Supplements[0].Supplement.Names.AR.Should().Be(suppliment.Names.AR);
            updatedDish.Supplements[0].Supplement.Names.EN.Should().Be(suppliment.Names.EN);
            updatedDish.Supplements[0].Supplement.Names.FR.Should().Be(suppliment.Names.FR);
            updatedDish.Supplements[0].Supplement.Names.TR.Should().Be(suppliment.Names.TR);
            updatedDish.Supplements[0].Supplement.Names.RU.Should().Be(suppliment.Names.RU);




        }

        private static async Task<UpdateDishCommand> UpdateDish(Dish dish, Guid ingredientId, Guid foodBusinessId)
        {
            var createDishSupplement = new CreateDishCommand
            {
                Name = "Supplement modified",
                Names = new NamesDto() { AR = "Supplement modified AR", EN = "Supplement modified EN", FR = "Supplement modified FR", TR = "Supplement modified TR", RU = "Supplement modified RU" },
                Description = "Supplement description modified",
                Picture = Properties.Resources.PictureBase64_02,
                Price = 100,
                FoodBusinessId = foodBusinessId.ToString(),
                IsSupplement = true,
                 IsQuantityChecked = true,
                 Quantity =200,
                EstimatedPreparationTime = 600
            };
            await SendAsync(createDishSupplement);

            var updateDishCommand = new UpdateDishCommand
            {
                Id = dish.DishId.ToString(),
                Name = "Fakhitasse modified",
                Names = new NamesDto() { AR = "Fakhitasse AR modified", EN = "Fakhitasse EN modified", FR = "Fakhitasse FR modified", TR = "Fakhitasse TR modified", RU = "Fakhitasse RU modified" },
                Description = "Fakhitasse description modified",
                Picture = Properties.Resources.PictureBase64_02,
                Price = 330,
                IsSupplement = false,
                 IsQuantityChecked = true,
                 Quantity =200,
                EstimatedPreparationTime = 600,
                Specifications = new List<DishSpecificationDto>() {
                    new  DishSpecificationDto()
                    {ContentType =  ContentType.CheckBox,
                    Names= new NamesDto(){AR="Slaty modified ar",EN="Slaty modified en",FR="Slaty modified fr",TR="Slaty modified tr",RU="Slaty modified ru"},
                    Title = "Slaty",
                    CheckBoxContent = false},
                    new  DishSpecificationDto()
                    {ContentType = ContentType.ComboBox,
                    Names= new NamesDto(){AR="Cuission modified ar",EN="Cuission modified en",FR="Cuission modified fr",TR="Cuission modified tr",RU="Cuission modified ru"},
                    Title = "Cuission modified",
                    ComboBoxContentTranslation=new List<TranslationItemDto>()
                    {
                        new TranslationItemDto()
                        {
                            Name="Bien Cuite modified",
                            Names=new NamesDto() {AR="Bien Cuite modified ar",EN="Bien Cuite modified en",FR="Bien Cuite fr",TR="Bien Cuite modified tr",RU="Bien Cuite modified ru"}
                        },
                        new TranslationItemDto()
                        {
                             Name="Demi cuisson modified",
                            Names=new NamesDto() {AR="Demi cuisson modified ar",EN="Demi cuisson modified en",FR="Demi cuisson modified fr",TR="Demi cuisson modified tr",RU="Demi cuisson modified ru"}
                        }
                    } }
                },
                Ingredients = new List<DishIngredientCreateDto>() {
                    new  DishIngredientCreateDto()   {
                        InitialAmount = 40,
                        MinimumAmount = 40,
                        MaximumAmount = 150,
                        MeasurementUnits = MeasurementUnits.KiloGramme,
                        AmountIncreasePerStep = 20,
                        PriceIncreasePerStep = 40,
                        IngredientId = ingredientId.ToString()
                    },
                },
                Supplements = new List<DishSupplementCreateDto>() {
                    new  DishSupplementCreateDto()   {SupplementId =  createDishSupplement.Id.ToString()},
                }
            };
            await SendAsync(updateDishCommand);
            return updateDishCommand;
        }
    }
}
