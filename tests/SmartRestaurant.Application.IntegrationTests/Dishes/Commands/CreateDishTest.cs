using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Dishes.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateDishTest : TestBase
    {    
        [Test]
        public async Task CreateIngredient_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);

            var createdDish = await GetDish(createDishCommand.Id);
            createdDish.Should().NotBeNull();
            createdDish.DishId.Should().Be(createDishCommand.Id);
            createdDish.Name.Should().Be(createDishCommand.Name);
            createdDish.Price.Should().Be( createDishCommand.Price);
            createdDish.FoodBusinessId.Should().Be(Guid.Parse(createDishCommand.FoodBusinessId));
            createdDish.IsSupplement.Should().Be(createDishCommand.IsSupplement);
            createdDish.EstimatedPreparationTime.Should().Be(createDishCommand.EstimatedPreparationTime);
            createdDish.Picture.Should().BeEquivalentTo(Convert.FromBase64String(createDishCommand.Picture));
            createdDish.CreatedBy.Should().Be(_authenticatedUserId);
            createdDish.CreatedAt.Should().NotBe(default);
            createdDish.LastModifiedBy.Should().BeNull();
            createdDish.LastModifiedAt.Should().Be(default);

            createdDish.Specifications.Should().HaveCount(2);
            createdDish.Specifications[0].Title.Should().Be(createDishCommand.Specifications[0].Title);
            createdDish.Specifications[0].ContentType.Should().Be(createDishCommand.Specifications[0].ContentType);
            createdDish.Specifications[0].CheckBoxContent.Should().Be(createDishCommand.Specifications[0].CheckBoxContent);
            createdDish.Specifications[0].ComboBoxContent.Should().BeNull();
            createdDish.Specifications[1].Title.Should().Be(createDishCommand.Specifications[1].Title);
            createdDish.Specifications[1].ContentType.Should().Be(createDishCommand.Specifications[1].ContentType);
            createdDish.Specifications[1].CheckBoxContent.Should().Be(createDishCommand.Specifications[1].CheckBoxContent);
            createdDish.Specifications[1].ComboBoxContent.Should().Be(string.Join(";", createDishCommand.Specifications[1].ComboBoxContent));

            createdDish.Ingredients.Should().HaveCount(1);
            createdDish.Ingredients[0].InitialAmount.Should().Be(createDishCommand.Ingredients[0].InitialAmount);
            createdDish.Ingredients[0].MinimumAmount.Should().Be(createDishCommand.Ingredients[0].MinimumAmount);
            createdDish.Ingredients[0].MaximumAmount.Should().Be(createDishCommand.Ingredients[0].MaximumAmount);
            createdDish.Ingredients[0].AmountIncreasePerStep.Should().Be(createDishCommand.Ingredients[0].AmountIncreasePerStep);
            createdDish.Ingredients[0].PriceIncreasePerStep.Should().Be(createDishCommand.Ingredients[0].PriceIncreasePerStep);
            createdDish.Ingredients[0].Ingredient.IngredientId.Should().Be(Guid.Parse(createDishCommand.Ingredients[0].IngredientId));

            createdDish.Supplements.Should().HaveCount(1);
            createdDish.Supplements[0].Supplement.DishId.Should().Be(Guid.Parse(createDishCommand.Supplements[0].SupplementId));
        }
    }
}
