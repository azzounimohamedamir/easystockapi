using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SmartRestaurant.Application.Buildings.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Buildings.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.Buildings.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteBuildingTests : TestBase
    {
        [Test]
        public async Task Shoulremovebuilding()

        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotelsafir = await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Hotel Safir");
            var building = await BuildingTestTools.CreateBuilding("safirbuilding", hotelsafir.Id);

            await SendAsync(new DeleteBuildingCommand
            {
                Id = building.Id
            });

            var buildingdelete = await FindAsync<Domain.Entities.Building>(building.Id);

            buildingdelete.Should().BeNull();
        }
    }
}