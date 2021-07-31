using System;
using System.Threading.Tasks;
using FluentAssertions;
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
    public class DeleteSectionTest
    {
        [Test]
        public async Task DeleteSection_ShouldSaveDb()
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
                Id = cmdId,
                Name = "test menu",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.Id
            });
            var sectionCmdId = Guid.NewGuid();
            await SendAsync(new CreateSectionCommand
            {
                Id = sectionCmdId,
                MenuId = cmdId,
                Name = "section test menu"
            });
            await SendAsync(new DeleteSectionCommand {Id = sectionCmdId});
            var item = await FindAsync<Section>(sectionCmdId);
            item.Should().BeNull();
        }
    }
}