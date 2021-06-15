using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Sections
{
    using static Testing;

    [TestFixture]
    public class UpdateSectionTest
    {
        [Test]
        public async Task UpdateSection_ShouldSaveToDB()
        {
            var createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var cmdId = Guid.NewGuid();
            await SendAsync(new CreateMenuCommand
            {
                CmdId = cmdId,
                Name = "test menu",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.CmdId
            });
            var sectionCmdId = Guid.NewGuid();
            await SendAsync(new CreateSectionCommand
            {
                CmdId = sectionCmdId,
                MenuId = cmdId,
                Name = "section test menu"
            });
            var validationResult = await SendAsync(new UpdateSectionCommand
            {
                CmdId = sectionCmdId,
                MenuId = cmdId,
                Name = "section 2 test menu"
            });
            var item = await FindAsync<Section>(sectionCmdId);
            validationResult.Should().Be(default(ValidationResult));
            item.Should().NotBeNull();
            item.Name.Should().Be("section 2 test menu");
            item.MenuId.Should().Be(cmdId);
        }
    }
}