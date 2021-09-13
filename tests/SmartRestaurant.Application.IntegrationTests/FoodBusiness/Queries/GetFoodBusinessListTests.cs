using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Queries
{
    using static Testing;

    public class GetFoodBusinessListTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllFoodBusinessList()
        {
            await RolesTestTools.CreateRoles();
            for (var i = 0; i < 5; i++)
            {
                var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
                await SendAsync(new CreateFoodBusinessCommand
                {
                    Name = "tacos Dz  " + i,
                    FoodBusinessAdministratorId = foodBusinessAdministrator.Id,
                    HasCarParking = true
                });
            }
            
            var query = new GetFoodBusinessListQuery {Page = 1, PageSize = 5};

            var result = await SendAsync(query);

            result.Data.Should().HaveCount(5);
        }
    }
}