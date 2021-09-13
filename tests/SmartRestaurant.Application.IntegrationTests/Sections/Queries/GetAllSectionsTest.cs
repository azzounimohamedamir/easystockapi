using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.Sections.Queries;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Sections.Queries
{
    using static Testing;

    [TestFixture]
    public class GetAllSectionsTest : TestBase
    {
        [Test]
        public async Task ShouldGetAllSections_ByFoodMenuId()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu",
                MenuState = (int) MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(createMenuCommand);
            for (var i = 0; i < 5; i++)
                await SendAsync(new CreateSectionCommand
                {
                    Name = "section test " + i,
                    MenuId = createMenuCommand.Id
                }).ConfigureAwait(false);
            var query = new GetSectionsListQuery {MenuId = createMenuCommand.Id, Page = 1, PageSize = 5};
            var result = await SendAsync(query);

            result.Data.Should().HaveCount(5);
        }
    }
}