using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
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
    public class DeleteSubSectionTest : TestBase
    {
        [Test]
        public async Task DeleteSection_ShouldSaveDb()
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
            var createSectionCommand = await SectionTestTools.CreateSection(createMenuCommand);

            var createSubSectionCommand = await SubSectionTestTools.CreateSubSection(createSectionCommand);
            await SendAsync(new DeleteSubSectionCommand { Id = createSubSectionCommand.Id });
            var item = await FindAsync<SubSection>(createSubSectionCommand.Id);
            item.Should().BeNull();
        }

 
    }
}