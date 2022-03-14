using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System;
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

            var updateDishCommand = await UpdateDish(dish);
            var updatedDish = await GetDish(Guid.Parse(updateDishCommand.Id));


            updatedDish.Should().NotBeNull();
            updatedDish.DishId.Should().Be(updateDishCommand.Id);
            updatedDish.Name.Should().Be(updateDishCommand.Name);
            updatedDish.Price.Should().Be(updateDishCommand.Price);
            updatedDish.FoodBusinessId.Should().Be(dish.FoodBusinessId);
            updatedDish.IsSupplement.Should().Be(updateDishCommand.IsSupplement);
            updatedDish.EstimatedPreparationTime.Should().Be(updateDishCommand.EstimatedPreparationTime);
            updatedDish.Picture.Should().BeEquivalentTo(Convert.FromBase64String(updateDishCommand.Picture));
            updatedDish.CreatedBy.Should().NotBeNull();
            updatedDish.CreatedAt.Should().NotBe(default);
            updatedDish.LastModifiedBy.Should().Be(_authenticatedUserId);
            updatedDish.LastModifiedAt.Should().NotBe(default);

            updatedDish.Specifications.Should().HaveCount(0);
            updatedDish.Ingredients.Should().HaveCount(0);
            updatedDish.Supplements.Should().HaveCount(0);



        }

        private static async Task<UpdateDishCommand> UpdateDish(Dish dish)
        {
            var updateDishCommand = new UpdateDishCommand
            {
                Id = dish.DishId.ToString(),
                Name = "Fakhitasse modified",
                Description = "Fakhitasse description modified",
                Picture = Properties.Resources.PictureBase64_02,
                Price = 330,
                IsSupplement = true,
                EstimatedPreparationTime = 600
            };
            await SendAsync(updateDishCommand);
            return updateDishCommand;
        }
    }
}
