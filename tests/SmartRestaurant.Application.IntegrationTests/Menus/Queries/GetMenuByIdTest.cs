using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Menus.Queries;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.IntegrationTests.Menus.Queries
{
    
    using static Testing;
    [TestFixture]
    public class GetMenuByIdTest  : TestBase
    {
        [Test]
        public async Task ShouldGetMenu_ById()
        {
            var foodBusinessId = Guid.NewGuid();

            CreateFoodBusinessCommand createFoodBusinessCommand = new CreateFoodBusinessCommand
            {
                CmdId = foodBusinessId,
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                Name = "fast food test"
            };
            await SendAsync(createFoodBusinessCommand);
            var cmdId = Guid.NewGuid();
            await SendAsync(new CreateMenuCommand
            {
                CmdId = cmdId,
                Name = "tacos Dz " ,
                MenuState = (int)MenuState.Enabled,
                FoodBusinessId = foodBusinessId

            }).ConfigureAwait(false);
            var query  =await SendAsync(new GetMenuByIdQuery() {MenuId = cmdId});
            query.Should().NotBeNull();
            query.Name.Should().Be("tacos Dz ");
        }
    }
}
