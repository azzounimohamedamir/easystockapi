using System;
using System.Threading.Tasks;
using FluentAssertions;
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
            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.Id
            };
            await SendAsync(createMenuCommand);
            var createSectionCommand = new CreateSectionCommand
            {
                MenuId = createMenuCommand.Id,
                Name = "section test menu"
            };
            await SendAsync(createSectionCommand);
            var createSubSectionCommand = new CreateSubSectionCommand
            {
                SectionId = createSectionCommand.Id,
                Name = "subsection test menu"
            };
            await SendAsync(createSubSectionCommand);
            var item = await FindAsync<SubSection>(createSubSectionCommand.Id);

            item.Should().NotBeNull();
            item.Name.Should().Be("subsection test menu");
            item.SectionId.Should().Be(createSectionCommand.Id);
        }
    }
}