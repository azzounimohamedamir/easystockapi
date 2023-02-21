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
    public class UpdateTypeReclamationCommandTest : TestBase
    {
        [Test]
        public async Task UpdateTypeReclamationCommand_ShouldUpdateInDB()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");
            var createtypeReclamationCommand = await ReclamationTestTools.CreateTypeReclamation("panne",hotel.Id); ;
            await SendAsync(new UpdateTypeReclamationCommand
            {
                Id = createtypeReclamationCommand.Id,
                HotelId=hotel.Id,
                Names = new Common.Dtos.ValueObjects.NamesDto() { AR = "AR", EN = "EN", FR = "FR", TR = "TR", RU = "RU" },
                Name = "Panne 2"
            });
            var item = await FindAsync<Domain.Entities.TypeReclamation>(createtypeReclamationCommand.Id);

            item.Should().NotBeNull();
            item.Name.Should().Be("Panne 2");
            item.Names.AR.Should().Be("AR");
            item.Names.EN.Should().Be("EN");
            item.Names.FR.Should().Be("FR");
            item.Names.TR.Should().Be("TR");
            item.Names.RU.Should().Be("RU");
            item.TypeReclamationId.Should().Be(createtypeReclamationCommand.Id);
        }
    }
}