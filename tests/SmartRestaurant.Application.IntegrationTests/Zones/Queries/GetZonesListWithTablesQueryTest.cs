using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Zones.Queries;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Zones.Queries
{
    using static Testing;

    public class GetZonesListWithTablesQueryTest : TestBase
    {
        [Test]
        public async Task ShouldReturnAllZonesListWithTables()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var names = new Dictionary<Guid, string>(); 
            for (var i = 0; i < 2; i++)
            {
                var id = Guid.NewGuid();
                names.Add(id,"zone " + id);

                var createZoneCommand = new CreateZoneCommand
                {
                    Id = id,
                    FoodBusinessId = fastFood.FoodBusinessId,
                    ZoneTitle = "zone " + id,
                    Names = new NamesDto()
                    {
                        AR = "zone " + id + "AR",
                        EN = "zone " + id + "EN",
                        FR = "zone " + id + "FR",
                        TR = "zone " + id + "TR",
                        RU = "zone " + id + "RU"
                    }
                };
                await SendAsync(createZoneCommand);
                var zone = await FindAsync<Zone>(createZoneCommand.Id);
                var createTableCommand = new CreateTableCommand
                {
                    Capacity = 4,
                    ZoneId = zone.ZoneId.ToString(),
                };
                await SendAsync(createTableCommand);
                var createTableCommand2 = new CreateTableCommand
                {
                    Capacity = 4,
                    ZoneId = zone.ZoneId.ToString(),
                };
                await SendAsync(createTableCommand2);


            }
            var query = new GetZonesListWithTablesQuery { FoodBusinessId = fastFood.FoodBusinessId.ToString()};
            var result = await SendAsync(query);
            result.Should().NotBeNull();
            var enumirator = result.GetEnumerator();

            while (enumirator.MoveNext())
            {
                var curent=enumirator.Current;
                curent.Names.AR.Should().Be(names[curent.ZoneId] + "AR");
                curent.Names.EN.Should().Be(names[curent.ZoneId] + "EN");
                curent.Names.FR.Should().Be(names[curent.ZoneId] + "FR");
                curent.Names.TR.Should().Be(names[curent.ZoneId] + "TR");
                curent.Names.RU.Should().Be(names[curent.ZoneId] + "RU");

            }
            result.Should().HaveCount(2);
            foreach (var item in result)    
            {
                item.Tables.Should().HaveCount(2);
            }
        }
    }
}