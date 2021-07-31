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
    public class UpdateSubSectionTest
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
            var subSectionCmdId = Guid.NewGuid();

            await SendAsync(new CreateSubSectionCommand
            {
                Id = subSectionCmdId,
                SectionId = sectionCmdId,
                Name = "subsection test menu"
            });
            var validationResult = await SendAsync(new UpdateSubSectionCommand
            {
                Id = subSectionCmdId,
                SectionId = sectionCmdId,
                Name = "subsection 2 test menu"
            });
            var item = await FindAsync<SubSection>(subSectionCmdId);
            validationResult.Should().Be(default(ValidationResult));
            item.Should().NotBeNull();
            item.Name.Should().Be("subsection 2 test menu");
            item.SectionId.Should().Be(sectionCmdId);
        }
    }
}