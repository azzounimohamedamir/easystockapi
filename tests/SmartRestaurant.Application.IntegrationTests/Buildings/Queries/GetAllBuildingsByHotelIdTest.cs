
using System.Threading.Tasks;
using FluentAssertions;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Buildings.Queries;
using NUnit.Framework;

namespace SmartRestaurant.Application.IntegrationTests.Buildings.Queries
{
    using static Testing;
    public class GetAllBuildingsByHotelIdQueryTest : TestBase
    {
        [Test]
        public async Task shouldReturnAllBuildingssByHotelId()
        {
            await RolesTestTools.CreateRoles();

            var foodBusinessAdmin = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel1 = await HotelTestTools.CreateHotel(foodBusinessAdmin.Id, "sofitel");
            var hotel2 = await HotelTestTools.CreateHotel(foodBusinessAdmin.Id, "safir");

            var building1_hotel1 = await BuildingTestTools.CreateBuilding("building1_hotel1", hotel1.Id);
            var building2_hotel1 = await BuildingTestTools.CreateBuilding("building2_hotel1", hotel1.Id);

            var building1_hotel2 = await BuildingTestTools.CreateBuilding("building1_hotel2", hotel2.Id);


            var query = new GetAllBuildingsByHotelId
            {
                HotelId = hotel1.Id,
                Page = 1,
                PageSize = 5,
            };
            var listofBuildingsOfHotel1 = await SendAsync(query);

            listofBuildingsOfHotel1.Data[0].Name= hotel1.Name;
            listofBuildingsOfHotel1.Data[1].Name = hotel1.Name;
            listofBuildingsOfHotel1.Data.Should().HaveCount(2);
        }
    }
}
