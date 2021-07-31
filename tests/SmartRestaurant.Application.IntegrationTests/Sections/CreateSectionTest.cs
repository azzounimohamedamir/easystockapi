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
    public class CreateSectionTest
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
            var cmdId = Guid.NewGuid();
            await SendAsync(new CreateMenuCommand
            {
                Id = cmdId,
                Name = "test menu",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = createFoodBusinessCommand.Id
            });
            var sectionCmdId = Guid.NewGuid();
            var validationResult = await SendAsync(new CreateSectionCommand
            {
                Id = sectionCmdId,
                MenuId = cmdId,
                Name = "section test menu"
            });
            var item = await FindAsync<Section>(sectionCmdId);
            validationResult.Should().Be(default(ValidationResult));
            item.Should().NotBeNull();
            item.Name.Should().Be("section test menu");
            item.MenuId.Should().Be(cmdId);
        }
    }
}