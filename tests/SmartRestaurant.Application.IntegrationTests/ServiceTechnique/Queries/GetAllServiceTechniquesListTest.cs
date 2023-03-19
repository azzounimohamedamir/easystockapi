using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.ServiceTechniqueDestination.Queries;

namespace SmartRestaurant.Application.IntegrationTests.TypeReclamation.Queries
{
    using static Testing;

    public class GetAllServiceTechniquesListTest : TestBase
    {
        [Test]
        public async Task ShouldGetAllServiceTechniquesListTest()
        {
            await RolesTestTools.CreateRoles();
            var foodbusinessManager = await UsersTestTools.CreateFoodBusinessManager();

            var hotel = await HotelTestTools.CreateHotel(foodbusinessManager.Id, "Sofitel");

            var createServiceTechnique = await ServiceTechniqueTestTools.CreateServiceTechnique( hotel.Id);

            var query = new GetAllServiceTechniquesDestinationByHotelIdQuery { HotelId = hotel.Id.ToString(), Page = 1 , PageSize=10 };

            var result = await SendAsync(query);

            result.Data.Should().HaveCount(1);
            result.Data[0].Names.AR.Should().Be(createServiceTechnique.Names.AR);
            result.Data[0].Names.FR.Should().Be(createServiceTechnique.Names.FR);
            result.Data[0].Names.EN.Should().Be(createServiceTechnique.Names.EN);
            result.Data[0].Names.RU.Should().Be(createServiceTechnique.Names.TR);
            result.Data[0].Names.TR.Should().Be(createServiceTechnique.Names.RU);
            result.Data[0].HotelId.Should().Be(createServiceTechnique.HotelId.ToString());


        }
    }
}