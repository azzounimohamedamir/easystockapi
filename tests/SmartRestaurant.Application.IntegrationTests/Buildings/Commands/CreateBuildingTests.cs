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
using SmartRestaurant.Application.Hotels.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.Buildings.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateBuildingTests : TestBase
    {
        [Test]
        public async Task CreateBuilding_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var hotel= await HotelTestTools.CreateHotel(foodBusinessAdministrator.Id, "Shiraton");

            List<IFormFile> formFiles = new List<IFormFile>();
            byte[] bytes = Convert.FromBase64String(Properties.Resources.PictureBase64_02);
            MemoryStream stream = new MemoryStream(bytes);
            IFormFile picture = new FormFile(stream, 0, bytes.Length, "Building 01", "Building.jpeg");

            var createBuildingCommand = new CreateBuildingCommand
            {
                Name = "Building 01",
                HotelId = hotel.Id,
                Picture = picture
            };
            await SendAsync(createBuildingCommand);

            var item = await FindAsync<Domain.Entities.Building>(createBuildingCommand.Id);

            item.Should().NotBeNull();
            item.HotelId.Should().Be(hotel.Id);
            item.Name.Should().BeEquivalentTo(createBuildingCommand.Name);
        }
    }
}