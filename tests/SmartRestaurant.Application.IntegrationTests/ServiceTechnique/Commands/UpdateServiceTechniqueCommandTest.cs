using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.TypeReclamation.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.TypeReclamation
{
    using static Testing;

    [TestFixture]
    public class UpdateServiceTechniqueCommandTest : TestBase
    {
        [Test]
        public async Task UpdateServiceTechniqueCommandTest_ShouldUpdateInDB()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");
            var createserviceTech = await ServiceTechniqueTestTools.CreateServiceTechnique(hotel.Id); ;
            await SendAsync(new UpdateServiceTechniqueCommand
            {
                Id = createserviceTech.Id,
                HotelId=hotel.Id,
                Names = new Common.Dtos.ValueObjects.NamesDto() { AR = "AR", EN = "EN", FR = "FR", TR = "TR", RU = "RU" }
            });
            var item = await FindAsync<Domain.Entities.ServiceTechnique>(createserviceTech.Id);

            item.Should().NotBeNull();
            item.Names.AR.Should().Be("AR");
            item.Names.EN.Should().Be("EN");
            item.Names.FR.Should().Be("FR");
            item.Names.TR.Should().Be("TR");
            item.Names.RU.Should().Be("RU");
            item.HotelId.Should().Be(hotel.Id);
        }
    }
}