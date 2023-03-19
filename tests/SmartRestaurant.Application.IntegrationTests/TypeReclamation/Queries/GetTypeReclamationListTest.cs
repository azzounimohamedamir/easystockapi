using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.TypeReclamation.Queries;

namespace SmartRestaurant.Application.IntegrationTests.TypeReclamation.Queries
{
    using static Testing;

    public class GetAllReclamationTypeListTest : TestBase
    {
        [Test]
        public async Task ShouldReturnAllReclamationTypeListTest()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");
            var serviceTechnique = await ServiceTechniqueTestTools.CreateServiceTechnique(hotel.Id);

            var createTypeReclamationCommand = await ReclamationTestTools.CreateTypeReclamation("panne", hotel.Id, serviceTechnique.Id);

            var query = new GetTypeReclamationListQuery { HotelId = hotel.Id.ToString(), Page = 1 , PageSize=10 };

            var result = await SendAsync(query);

            result.Data.Should().HaveCount(1);
            result.Data[0].Name.Should().Be(createTypeReclamationCommand.Name);
            result.Data[0].Names.AR.Should().Be(createTypeReclamationCommand.Names.AR);
            result.Data[0].Names.FR.Should().Be(createTypeReclamationCommand.Names.FR);
            result.Data[0].Names.EN.Should().Be(createTypeReclamationCommand.Names.EN);
            result.Data[0].Names.RU.Should().Be(createTypeReclamationCommand.Names.TR);
            result.Data[0].Names.TR.Should().Be(createTypeReclamationCommand.Names.RU);
            result.Data[0].HotelId.Should().Be(createTypeReclamationCommand.HotelId.ToString());


        }
    }
}