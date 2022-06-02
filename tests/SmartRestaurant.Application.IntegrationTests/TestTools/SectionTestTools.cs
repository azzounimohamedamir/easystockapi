using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.Zones.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;
    public class SectionTestTools
    {
        public static async Task<CreateSectionCommand> CreateSection(CreateMenuCommand createMenuCommand,string name= "section test menu")
        {
            var createSectionCommand = new CreateSectionCommand
            {
                MenuId = createMenuCommand.Id,
                Names = new NamesDto() { AR = "AR", EN = "EN", FR = "FR", TR = "TR", RU = "RU" },
                Name = name
            };
            await SendAsync(createSectionCommand);
            return createSectionCommand;
        }
    }
}
