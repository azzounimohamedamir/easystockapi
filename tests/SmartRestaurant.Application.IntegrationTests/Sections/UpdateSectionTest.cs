using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Sections
{
    using static Testing;

    [TestFixture]
    public class UpdateSectionTest : TestBase
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
            await SendAsync(new UpdateSectionCommand
            {
                Id = createSectionCommand.Id,
                MenuId = createMenuCommand.Id,
                Name = "section 2 test menu"
            });
            var item = await FindAsync<Section>(createSectionCommand.Id);

            item.Should().NotBeNull();
            item.Name.Should().Be("section 2 test menu");
            item.MenuId.Should().Be(createMenuCommand.Id);
        }
    }
}