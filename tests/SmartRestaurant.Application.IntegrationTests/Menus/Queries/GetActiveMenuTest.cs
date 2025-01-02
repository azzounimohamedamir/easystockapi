using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Menus.Queries;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Menus.Queries
{
    using static Testing;

    [TestFixture]
    public class GetActiveMenuTest : TestBase
    {
        [Test]
        public async Task ShouldGetAllMenus_ByFoodBusinessId()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            for (var i = 0; i < 5; i++)
            {
                await SendAsync(new CreateProductOnStockCommand
                {
                    Name = "tacos Dz  " + i,
                    FoodBusinessId = fastFood.FoodBusinessId
                });
            }

            var menuId = Guid.NewGuid();
            var CreateMenueCommand = new CreateProductOnStockCommand
            {
                Id = menuId,
                Name = "test menu",
                FoodBusinessId = fastFood.FoodBusinessId
            };
            await SendAsync(CreateMenueCommand);
            await SendAsync(new UpdateProductOnStockCommand
            {
                Id = menuId,
                Name = "test menu -- enabled",
                MenuState = MenuState.Enabled,
                FoodBusinessId = fastFood.FoodBusinessId
            });
            var createSectionCommand = await SectionTestTools.CreateSection(CreateMenueCommand);
            var createSubSectionCommand = await SubSectionTestTools.CreateSubSection(createSectionCommand);
            var result = await SendAsync(new GetActiveMenuQuery { FoodBusinessId = fastFood.FoodBusinessId.ToString() });
            result.MenuId.Should().Be(menuId);
            result.Name.Should().Be("test menu -- enabled");
            result.Sections[0].Order.Should().Be(1);
            result.Sections[0].SubSections[0].Order.Should().Be(1);
        }
    }
}