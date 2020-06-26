using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Restaurants.Commands;
using SmartRestaurant.Domain.Entities;
using System.Threading.Tasks;
using Xunit;

namespace SmartRestaurant.Application.IntegrationTests.IntegrationTest
{
    using static Testing;
    public class RestaurantIntegrationTest : TestBase
    {
        [Test]
        public async Task CreateRestaurant_SouldSaveDB()
        {
            Restaurant restaurant = new Restaurant();
            restaurant.UpdateRestaurantInfo(



                 "تاج محل",
                 "Taj mahal",
                 "Taj mahal",
                 "It's a traditional indian restaurant",
                 true,
                 true,
                 true,
                 true,
                 "#TAJ#Mahal",
                 "", 4, 645);
            restaurant.LocatedAt("Didouche Mourad", "Algiers", "Algeria");
            restaurant.ChangePhoneNumber(213, 670217536);

            CreateRestaurantCommand createRestaurantCommand = new CreateRestaurantCommand();
            Restaurant RestaurantFind = new Restaurant();
            RestaurantFind.Should().BeEquivalentTo(restaurant);
            
            var itemId = await SendAsync(createRestaurantCommand);

            var item = await FindAsync<Restaurant>(itemId);

            item.Should().BeEquivalentTo(restaurant);
        }
        //deleteRestaurant_ShouldSaveDB
    }
}
