using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Buildings.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Buildings.Commands
{
    using static Testing;

    public class UpdateBuildingTests : TestBase
    {
        [Test]
        public async Task ShouldUpdateBuilding()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotelsafir = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Hotel Safir");
            var building = await BuildingTestTools.CreateBuilding("safirbuilding", hotelsafir.Id);

            await Task.Delay(0).ContinueWith(async t =>
            {
                var updateBuildingCommand = new UpdateBuildingCommand
                {
                    

                    Name = "Newsafirbuilding",
                  
                    Picture = "newpicture"
                };

                await SendAsync(updateBuildingCommand);

                var list = await FindAsync<Domain.Entities.Building>(building.Id);

                list.Id.Should().Be(updateBuildingCommand.Id);
                list.Name.Should().Be("Newsafirbuilding");

            });
        }
    }
}