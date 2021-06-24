using SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness.ViewModels;
using Xunit;

namespace SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness
{
    public class CreateFoodBusiness
    {
        [Fact]
        public async void CreateFoodBusiness_WhenNotAuthenticated_ShouldReturnPermissionException()
        {
            var api = new Configuration.WebApi();

            var response = await api.Post<FoodBusinessModel>("/foodbusiness", new {});

            Assert.Null(response.Content);
            Assert.Equal(401, response.StatusCode);
        }

        [Fact]
        public async void CreateFoodBusiness_WhenNotAuthorized_ShouldReturnPermissionException()
        {
            var api = new Configuration.WebApi();

            await api.Sign("Waiter@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Post<FoodBusinessModel>("/foodbusiness", new {});

            Assert.Null(response.Content);
            Assert.Equal(403, response.StatusCode);
        }
    }
}