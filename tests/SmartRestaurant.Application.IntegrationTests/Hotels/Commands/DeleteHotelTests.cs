using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Hotels.Commands;
using SmartRestaurant.Application.Hotels.Queries;

using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.Hotels.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteHotelTests : TestBase
    {
        [Test]
        public async Task DeleteHotelTask()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hilton = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id,"Hilton");

            await SendAsync(new DeleteHotelCommand
            {
                Id = hilton.Id
            });

            var hotel = await FindAsync<Domain.Entities.Hotel>(hilton.Id);

            hotel.Should().BeNull();

        }
    }
}