using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Application.SubSections.Queries;
using SmartRestaurant.Domain.Enums;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.SubSections.Queries
{
    using static Testing;

    [TestFixture]
    public class GetSubSectionByIdTests : TestBase
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
            var createSubSectionCommand=await SubSectionTestTools.CreateSubSection(createSectionCommand, "sub-section test").ConfigureAwait(false); 
        
            var query = new GetSubSectionByIdQuery { Id = createSubSectionCommand.Id.ToString()};
            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.Name.Should().Be("sub-section test");
            result.Names.AR.Should().Be("AR");
            result.Names.EN.Should().Be("EN");
            result.Names.FR.Should().Be("FR");
            result.Names.TR.Should().Be("TR");
            result.Names.RU.Should().Be("RU");
            result.SectionId.Should().Be(createSectionCommand.Id);
        }
    }
}
