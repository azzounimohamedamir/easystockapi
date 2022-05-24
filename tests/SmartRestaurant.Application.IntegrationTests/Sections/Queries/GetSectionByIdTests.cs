using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.Sections.Queries;
using SmartRestaurant.Domain.Enums;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Sections.Queries
{
    using static Testing;

    [TestFixture]
    public class GetSectionByIdTests : TestBase
    {
        [Test]
        public async Task ShouldGetSectionDetails()
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

            var createSectionCommand = await SectionTestTools.CreateSection(createMenuCommand, "section test");
            
            var query = new GetSectionByIdQuery { Id = createSectionCommand.Id.ToString()};
            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.Name.Should().Be("section test");
            result.Names.AR.Should().Be("AR");
            result.Names.EN.Should().Be("EN");
            result.Names.FR.Should().Be("FR");
            result.Names.TR.Should().Be("TR");
            result.Names.RU.Should().Be("RU");
            result.MenuId.Should().Be(createMenuCommand.Id);
        }
    }
}
