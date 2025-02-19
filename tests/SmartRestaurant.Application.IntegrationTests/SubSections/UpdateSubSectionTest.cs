﻿using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.SubSections
{
    using static Testing;

    [TestFixture]
    public class UpdateSubSectionTest : TestBase
    {
        [Test]
        public async Task UpdateSection_ShouldSaveToDB()
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

            var createSubSectionCommand = await SubSectionTestTools.CreateSubSection(createSectionCommand);

            await SubSectionTestTools.UpdateSubSection(createSectionCommand, createSubSectionCommand, "subsection 2 test menu");
            var item = await FindAsync<SubSection>(createSubSectionCommand.Id);

            item.Should().NotBeNull();
            item.Name.Should().Be("subsection 2 test menu");
            item.Order.Should().Be(2);
            item.Names.AR.Should().Be("AR");
            item.Names.EN.Should().Be("EN");
            item.Names.FR.Should().Be("FR");
            item.Names.TR.Should().Be("TR");
            item.Names.RU.Should().Be("RU");
            item.SectionId.Should().Be(createSectionCommand.Id);
        }
    }
}