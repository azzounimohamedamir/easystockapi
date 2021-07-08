using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.SubSections
{
    using static Testing;

    [TestFixture]
    public class CreateSubSectionTest
    {
        [Test]
        public async Task CreateSection_ShouldSaveToDB()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var menuCmdId = Guid.NewGuid();
            await SendAsync(new CreateMenuCommand
            {
                CmdId = menuCmdId,
                Name = "test menu",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.CmdId
            });
            var sectionCmdId = Guid.NewGuid();
            await SendAsync(new CreateSectionCommand
            {
                CmdId = sectionCmdId,
                MenuId = menuCmdId,
                Name = "section test menu"
            });
            var subSectionCmdId = Guid.NewGuid();
            var validationResult = await SendAsync(new CreateSubSectionCommand
            {
                CmdId = subSectionCmdId,
                SectionId = sectionCmdId,
                Name = "subsection test menu"
            });
            var item = await FindAsync<SubSection>(subSectionCmdId);
            validationResult.Should().Be(default(ValidationResult));
            item.Should().NotBeNull();
            item.Name.Should().Be("subsection test menu");
            item.SectionId.Should().Be(sectionCmdId);
        }
    }
}