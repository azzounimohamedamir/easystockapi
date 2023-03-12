using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class TablesTestTools
    {
        public static async Task CreateTable(CreateZoneCommand createZoneCommand)
        {
            var createTableCommand = new CreateTableCommand
            {
                Id = Guid.Parse("44aecd78-59bb-7504-bfff-07c07129ab00"),
                Capacity = 4,
                ZoneId = createZoneCommand.Id.ToString()
            };
            await SendAsync(createTableCommand);
           
        }

        public static async Task CreateTableWithId(CreateZoneCommand createZoneCommand, string idTable)
        {
            var createTableCommand01 = new CreateTableCommand
            {
                Id = Guid.Parse(idTable),
                Capacity = 4,
                ZoneId = createZoneCommand.Id.ToString()
            };
            await SendAsync(createTableCommand01);
        }

    }
}
