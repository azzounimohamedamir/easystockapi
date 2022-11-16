using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusiness.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Queries
{
    using static Testing;


    public class GetAllFoodBusinessThatAcceptDeliveryTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllFoodBusinessThatAcceptDeliveryAssignedToDinerTests()
        {
            await RolesTestTools.CreateRoles();

            var tacosDzFoodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var tacosDz1 = await FoodBusinessTestTools.CreateFoodBusinessWithDelivery(tacosDzFoodBusinessAdministrator.Id, "tacos Dz 01",true);           
            var tacosDz2 = await FoodBusinessTestTools.CreateFoodBusinessWithDelivery(tacosDzFoodBusinessAdministrator.Id, "tacos Dz 02",false);           
            var tacosDz3 = await FoodBusinessTestTools.CreateFoodBusinessWithDelivery(tacosDzFoodBusinessAdministrator.Id, "tacos Dz 03",true);


            var result = await SendAsync(new GetAllFoodBusinessAccpetsImportationQuery());

            result.Data.Should().HaveCount(2);
        }
    }
}