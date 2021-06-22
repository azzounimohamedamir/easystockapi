using SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness.ViewModels;
using Xunit;

namespace SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness
{
    public class GetFoodBusinessById
    {
        [Fact]
        public async void GetFoodBusinessById_WhenNotAuthenticated_ShouldReturnPermissionException()
        {
            var api = new Configuration.WebApi();

            var response = await api.Get<FoodBusinessModel>("/foodbusiness/3cbf3570-4444-4673-8746-29b7cf568093");

            Assert.Null(response.Content);
            Assert.Equal(401, response.StatusCode);
        }

        [Fact]
        public async void GetFoodBusinessById_WhenNotAuthorized_ShouldReturnPermissionException()
        {
            var api = new Configuration.WebApi();

            await api.Sign("Waiter@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Get<FoodBusinessModel>("/foodbusiness/3cbf3570-4444-4673-8746-29b7cf568093");

            Assert.Null(response.Content);
            Assert.Equal(403, response.StatusCode);
        }

        [Fact]
        public async void GetFoodBusinessById_WrongPageQueryParameter_ShouldReturn404()
        {
            var api = new Configuration.WebApi();

            await api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Get<FoodBusinessModel>("/foodbusiness/123");

            Assert.Null(response.Content);
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public async void GetFoodBusinessById_WhenIdDoesntExist_ShouldReturnNull()
        {
            var api = new Configuration.WebApi();

            await api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@");

            var response =
                await api.Get<FoodBusinessModel>("/foodbusiness/64b711d3-75a1-48f8-989e-0ff2a699bc94");

            Assert.Null(response.Content);
            Assert.Equal(500, response.StatusCode);
        }

        [Fact]
        public async void GetFoodBusinessById_AuthenticatedAndAuthorized_ShouldReturnOK()
        {
            var api = new Configuration.WebApi();

            await api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@");

            var response =
                await api.Get<FoodBusinessModel>("/foodbusiness/3cbf3570-4444-4673-8746-29b7cf568093");

            Assert.NotNull(response.Content);
            Assert.Equal(200, response.StatusCode);
        }
    }
}