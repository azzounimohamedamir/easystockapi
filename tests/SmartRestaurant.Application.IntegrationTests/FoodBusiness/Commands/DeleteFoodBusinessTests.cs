using System;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using SmartRestaurant.Application.FoodBusiness.Commands;

namespace SmartRestaurant.Application.IntegrationTests.Restaurants.Commands
{
    using static Testing;
    [TestFixture]
    public class DeleteFoodBusinessTests : TestBase
    {
        [Test]
        public async Task DeleteRestaurant_ShouldSaveToDB()
        {
            var createCommand = new CreateFoodBusinessCommand()
            {
                NameEnglish = "Taj mahal",
                CmdId = Guid.NewGuid()
            };
            await SendAsync(createCommand);
            await SendAsync(new DeletefoodBusinessCommand
            {
                RestaurantId = createCommand.CmdId
                
            });

            var restaurantIdFound = await FindAsync<Domain.Entities.FoodBusiness>(createCommand.CmdId);
            restaurantIdFound.Should().BeNull();
        }
    }
}
