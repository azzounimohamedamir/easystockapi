using System.Collections.Generic;
using SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness.ViewModels;
using Xunit;

namespace SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness
{
    public class GetFoodBusinessByAdministratorId
    {
        [Fact]
        public async void GetFoodBusinessByAdministratorId_WhenNotAuthenticated_ShouldReturnPermissionException()
        {
            var api = new Configuration.WebApi();

            var response = await api.Get<FoodBusinessModel>("/foodbusiness/123/foodBusinessAdministrator");

            Assert.Null(response.Content);
            Assert.Equal(401, response.StatusCode);
        }

        [Fact]
        public async void GetFoodBusinessByAdministratorId_WhenNotAuthorized_ShouldReturnPermissionException()
        {
            var api = new Configuration.WebApi();

            await api.Sign("Waiter@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Get<FoodBusinessModel>("/foodbusiness/123/foodBusinessAdministrator");

            Assert.Null(response.Content);
            Assert.Equal(403, response.StatusCode);
        }

        [Fact]
        public async void GetFoodBusinessByAdministratorId_WrongPageQueryParameter_ShouldReturnNoData()
        {
            var api = new Configuration.WebApi();

            await api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Get<FoodBusinessModel>("/foodbusiness/123/foodBusinessAdministrator");

            Assert.Null(response.Content);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void GetFoodBusinessByAdministratorId_AuthenticatedAndAuthorized_ShouldReturnOK()
        {
            var api = new Configuration.WebApi();

            await api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@");

            var response =
                await api.Get<List<FoodBusinessModel>>(
                    "/foodbusiness/3cbf3570-4444-4444-8746-29b7cf568093/foodBusinessAdministrator");

            Assert.NotNull(response.Content);
            Assert.Equal(200, response.StatusCode);
        }
    }
}