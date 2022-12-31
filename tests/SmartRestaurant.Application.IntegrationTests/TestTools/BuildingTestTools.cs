using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Buildings.Commands;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class BuildingTestTools
    {
        public static async Task<Domain.Entities.Building> CreateBuilding(string BuildingName, Guid hotelId)
        {
            var buildingCommand = new CreateBuildingCommand()
            {
               Name=BuildingName,
               HotelId=hotelId,
               Picture=""

            };
          
                await SendAsync(buildingCommand);
           
            var building = await FindAsync<Domain.Entities.Building>(buildingCommand.Id);
            return building;
        }


    }
}