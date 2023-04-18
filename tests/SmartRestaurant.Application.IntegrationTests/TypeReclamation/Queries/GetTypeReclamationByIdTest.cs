using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.TypeReclamation.Queries;
using SmartRestaurant.Application.TypeReclamation.Commands;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.TypeReclamation.Queries
{
    using static Testing;

    public class GetTypeReclamationByIdTest : TestBase
    {
        [Test]
        public async Task ShouldReturnTypeReclamation()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");
            var serviceTechnique = await ServiceTechniqueTestTools.CreateServiceTechnique(hotel.Id);

            var createTypeReclamationCommand = await ReclamationTestTools.CreateTypeReclamation("panne", hotel.Id, serviceTechnique.Id);

            var query = new GetTypeReclamationByIdQuery { TypeReclamationId = createTypeReclamationCommand.Id.ToString() };

            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.Name.Should().Be("panne");
            result.Names.AR.Should().Be("عطل");
            result.Names.FR.Should().Be("panne");
            result.Names.EN.Should().Be("panne");
            result.Names.RU.Should().Be("panne");
            result.Names.TR.Should().Be("panne");
            result.Delai.Should().Be(5);
            result.ServiceTechniqueId.Should().Be(serviceTechnique.Id);
        }
    }
}