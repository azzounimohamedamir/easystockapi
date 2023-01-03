using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Application.SubSections.Queries;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.SubSections.Queries
{
    using static Testing;

    [TestFixture]
    public class GetAllSubSectionsByFoodBusinessIdTest : TestBase
    {
        [Test]
        public async Task ShouldGetAllSubsectionByfoodBusinessId_FromDb()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var fastFood2 = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createMenuCommand = new CreateMenuCommand
            {
                Name = "test menu",
                FoodBusinessId = fastFood.FoodBusinessId
            };

            var createMenuCommand2 = new CreateMenuCommand
            {
                Name = "test menu 2",
                FoodBusinessId = fastFood2.FoodBusinessId
            };
            await SendAsync(createMenuCommand);
            await SendAsync(createMenuCommand2);

            var createSectionCommand = await SectionTestTools.CreateSection(createMenuCommand, "section test");
            var createSectionCommand2 = await SectionTestTools.CreateSection(createMenuCommand2, "section test 2");

            await SubSectionTestTools.CreateSubSection(createSectionCommand, "sub-section test ").ConfigureAwait(false);
              await SubSectionTestTools.CreateSubSection(createSectionCommand2, "sub-section test 2 ").ConfigureAwait(false);

            var query = new GetAllSubSectionsListQuery { FoodBusinessId=fastFood.FoodBusinessId.ToString()};
            var result = await SendAsync(query);

            result.Should().HaveCount(1);
            result[0].Name.Should().Be("sub-section test ");
            
        }
    }
}