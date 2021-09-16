using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Commands
{
    using static Testing;

    [TestFixture]
    public class DeleteFoodBusinessTests : TestBase
    {
        [Test]
        public async Task DeleteFoodBusinessTask()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);


            await SendAsync(new DeleteFoodBusinessCommand
            {
                Id = fastFood.FoodBusinessId
            });

            var foodBusiness = await FindAsync<Domain.Entities.FoodBusiness>(fastFood.FoodBusinessId);
            foodBusiness.Should().BeNull();
        }
    }
}