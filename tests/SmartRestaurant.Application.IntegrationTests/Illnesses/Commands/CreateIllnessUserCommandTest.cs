using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using SmartRestaurant.Application.Illness.Queries;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Commands
{
    using static Testing;
    [TestFixture]
    public class CreateIllnessUserCommandTest : TestBase
    {
        [Test]
        public async Task CreateIllnessUser_ShouldSaveToDB()
        {
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createIllnes1 = await IllnessTestTools.CreateIllness(createIngredientCommand.Id);

            var illnessid1 = await GetIllness(createIllnes1.Id);

            List<string> listOfIlnessIds = new List<string> { illnessid1.IllnessId.ToString() };

            var createIllnessUserCommandFirstTime = await IllnessUserTestTools.CreateIllnessUser(listOfIlnessIds);

          

            var tableInlessUserInFirstAdd = GetAllIlnessUserList();

            tableInlessUserInFirstAdd.Result.Count.Should().Be(1);

            var createIllnessUserCommandSecondTime = await IllnessUserTestTools.CreateIllnessUser(listOfIlnessIds);

       

            var tableInlessUserInSecondAdd = GetAllIlnessUserList();

            tableInlessUserInFirstAdd.Result.Count.Should().Be(1);


        }
    }
}
