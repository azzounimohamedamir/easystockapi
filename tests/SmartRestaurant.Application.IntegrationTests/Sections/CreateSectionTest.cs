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
    public class CreateSectionTest : TestBase
    {
        [Test]
        public async Task CreateSection_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createMenuCommand = new CreateProductOnStockCommand
            {
                Name = "test menu",
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createMenuCommand);
            var createSectionCommand = await SectionTestTools.CreateSection(createMenuCommand);
            var item = await FindAsync<Section>(createSectionCommand.Id);

            item.Should().NotBeNull();
            item.Name.Should().Be("section test menu");
            item.Order.Should().Be(1);
            item.Names.AR.Should().Be("AR");
            item.Names.EN.Should().Be("EN");
            item.Names.FR.Should().Be("FR");
            item.Names.TR.Should().Be("TR");
            item.Names.RU.Should().Be("RU");
            item.MenuId.Should().Be(createMenuCommand.Id);
        }
    }
}