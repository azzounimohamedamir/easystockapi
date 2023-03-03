using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;

    public class UpdateFoodBusinessRatingTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateFoodBusinessRating()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var loggedInUser = await UsersTestTools.CreateClient(_authenticatedUserId);

            await Task.Delay(0).ContinueWith(async t =>
            {
                var updateFoodBusinessRatingCommand = new UpdateFoodBusinessRatingCommand
                {
                    FoodBusinessId = fastFood.FoodBusinessId.ToString(),
                    Rating = 5
                };

                await SendAsync(updateFoodBusinessRatingCommand);

                var list = await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);

                list.FoodBusinessId.Should().Be(fastFood.FoodBusinessId);
                list.AverageRating.Should().Be(5);
                list.Ratings.Should().HaveCount(1);
            });
        }
    }
}