using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;
    public class SubSectionTestTools
    {
        public static async Task<CreateSubSectionCommand> CreateSubSection(CreateSectionCommand createSectionCommand,string name= "subsection test menu",int order=1)
        {
            var createSubSectionCommand = new CreateSubSectionCommand
            {
                SectionId = createSectionCommand.Id,
                Order = order,
                Names = new NamesDto() { AR = "AR", EN = "EN", FR = "FR", TR = "TR", RU = "RU" },
                Name = name
            };
            await SendAsync(createSubSectionCommand);
            return createSubSectionCommand;
        }
        public static async Task UpdateSubSection(CreateSectionCommand createSectionCommand, CreateSubSectionCommand createSubSectionCommand, string NewName)
        {
            await SendAsync(new UpdateSubSectionCommand
            {
                Id = createSubSectionCommand.Id,
                Order=2,
                SectionId = createSectionCommand.Id,
                Name = NewName,
                Names = new NamesDto() { AR = "AR", EN = "EN", FR = "FR", TR = "TR", RU = "RU" },
            });
        }
    }
}
