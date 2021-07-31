using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
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
            for (var i = 0; i < 5; i++)
                await SendAsync(new CreateSectionCommand
                {
                    Name = "section test " + i,
                    MenuId = cmdId
                }).ConfigureAwait(false);
            var query = new GetSectionsListQuery {MenuId = cmdId, Page = 1, PageSize = 5};
            var result = await SendAsync(query);

            result.Data.Should().HaveCount(5);
        }
    }
}