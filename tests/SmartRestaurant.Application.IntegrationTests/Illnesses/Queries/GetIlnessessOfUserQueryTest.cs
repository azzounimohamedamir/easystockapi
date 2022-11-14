


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.Illness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.Hotels.Queries
{
    using static Testing;


    public class GetIlnessessOfUserQueryTest : TestBase
    {
        [Test]
        public async Task ShouldReturnAllHotelsAssignedToFoodBusinessAdminTests()
        {
            await RolesTestTools.CreateRoles();
            var TajMhalFoodBusinessManager = await UsersTestTools.CreateFoodBusinessAdministrator(_authenticatedUserId);

            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createIllnes1 = await IllnessTestTools.CreateIllness(createIngredientCommand.Id);

            var illnessid1 = await GetIllness(createIllnes1.Id);

            List<string> listOfIlnessIds = new List<string> { illnessid1.IllnessId.ToString() };

            var createIllnessUserCommandFirstTime = await IllnessUserTestTools.CreateIllnessUser(listOfIlnessIds);


            var query = new GetIlnessessbyUserQuery
            {
            };
            var result = await SendAsync(query);


            result.Data.Count.Should().Be(1);
            result.Should().NotBeNull();
            result.Data[0].ApplicationUserId.Should().Be(_authenticatedUserId);

        }
    }
}