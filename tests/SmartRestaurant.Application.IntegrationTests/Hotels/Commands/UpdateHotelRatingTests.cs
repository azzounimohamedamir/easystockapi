using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Hotels.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.Hotels.Commands
{
    using static Testing;

    public class UpdateHotelRatingTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateHotelRating()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hilton = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Hilton");
            var loggedInUser = await UsersTestTools.CreateClient(_authenticatedUserId);

            await Task.Delay(0).ContinueWith(async t =>
            {
                var updateHotelRatingCommand = new UpdateHotelRatingCommand
                {
                    HotelId = hilton.Id.ToString(),
                    Rating = 5
                };

                await SendAsync(updateHotelRatingCommand);

                var list = await FindAsync<Domain.Entities.Hotel>(hilton.Id);

                list.Id.Should().Be(hilton.Id);
                list.AverageRating.Should().Be(5);
                list.Ratings.Should().HaveCount(1);
            });
        }
    }
}