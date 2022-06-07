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
            var createSectionCommand = await SectionTestTools.CreateSection(createMenuCommand);
            await SendAsync(new UpdateSectionCommand
            {
                Id = createSectionCommand.Id,
                Order=2,
                MenuId = createMenuCommand.Id,
                Names = new Common.Dtos.ValueObjects.NamesDto() { AR = "AR", EN = "EN", FR = "FR", TR = "TR", RU = "RU" },
                Name = "section 2 test menu"
            });
            var item = await FindAsync<Section>(createSectionCommand.Id);

            item.Should().NotBeNull();
            item.Name.Should().Be("section 2 test menu");
            item.Order.Should().Be(2);
            item.Names.AR.Should().Be("AR");
            item.Names.EN.Should().Be("EN");
            item.Names.FR.Should().Be("FR");
            item.Names.TR.Should().Be("TR");
            item.Names.RU.Should().Be("RU");
            item.MenuId.Should().Be(createMenuCommand.Id);
        }
    }
}