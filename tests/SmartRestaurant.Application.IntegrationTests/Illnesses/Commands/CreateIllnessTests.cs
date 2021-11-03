using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Illnesses.Commands
{
    using static Testing;
    [TestFixture]
    public class CreateIllnessTests : TestBase
    {
        [Test]
        public async Task CreateIllness_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
           
            var createIllnessCommand = new CreateIllnessCommand
            {
                Name = "Illness test"
            };
            await SendAsync(createIllnessCommand);
            var item = await FindAsync<Domain.Entities.Illness>(createIllnessCommand.Id);

            item.Should().NotBeNull();
            item.Name.Should().Be("Illness test");
            item.IllnessId.Should().Be(createIllnessCommand.Id);
        }
    }
}
