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
                MenuState = (int)MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createMenuCommand);

           
            var createSectionCommand = new CreateSectionCommand
            {
                Name = "section test",
                MenuId = createMenuCommand.Id
            };
            await SendAsync(createSectionCommand).ConfigureAwait(false);


            var createSubSectionCommand = new CreateSubSectionCommand
            {
                Name = "sub-section test",
                SectionId = createSectionCommand.Id
            };
            await SendAsync(createSubSectionCommand).ConfigureAwait(false);


            var query = new GetSubSectionByIdQuery { Id = createSubSectionCommand.Id.ToString()};
            var result = await SendAsync(query);
            result.Should().NotBeNull();
            result.Name.Should().Be("sub-section test");
            result.SectionId.Should().Be(createSectionCommand.Id);
        }
    }
}
