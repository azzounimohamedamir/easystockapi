using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.SubSections
{
    using static Testing;

    [TestFixture]
    public class UpdateSubSectionTest : TestBase
    {
        [Test]
        public async Task UpdateSection_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu",
                FoodBusinessId = fastFood.FoodBusinessId
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
            await SendAsync(new UpdateSubSectionCommand
            {
                Id = createSubSectionCommand.Id,
                SectionId = createSectionCommand.Id,
                Name = "subsection 2 test menu"
            });
            var item = await FindAsync<SubSection>(createSubSectionCommand.Id);

            item.Should().NotBeNull();
            item.Name.Should().Be("subsection 2 test menu");
            item.SectionId.Should().Be(createSectionCommand.Id);
        }
    }
}