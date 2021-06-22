using SmartRestaurant.WebApi.Tests.Common;
using SmartRestaurant.WebApi.Tests.Controllers.User.ViewModels;
using Xunit;

namespace SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness
{
    public class GetFoodBusinesses
    {
        [Fact]
        public async void GetListFoodBusinesses_WhenNotAuthenticated_ShouldReturnPermissionException()
        {
            var api = new Configuration.WebApi();

            var response = await api.Get<DataList<UserModel>>("/foodbusiness");

            Assert.Null(response.Content);
            Assert.Equal(401, response.StatusCode);
        }

        [Fact]
        public async void GetListFoodBusinesses_WhenNotAuthorized_ShouldReturnPermissionException()
        {
            var api = new Configuration.WebApi();

            await api.Sign("Waiter@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Get<DataList<UserModel>>("/foodbusiness");

            Assert.Null(response.Content);
            Assert.Equal(403, response.StatusCode);
        }

        [Fact]
        public async void GetListFoodBusinesses_WrongPageQueryParameter_ShouldReturnNoData()
        {
            var api = new Configuration.WebApi();

            await api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Get<DataList<UserModel>>("/foodbusiness?page=tests");

            Assert.Null(response.Content);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void GetListFoodBusinesses_AuthenticatedAndAuthorized_ShouldReturnOK()
        {
            var api = new Configuration.WebApi();

            await api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Get<DataList<UserModel>>("/foodbusiness");

            Assert.NotNull(response.Content);
            Assert.Equal(200, response.StatusCode);
        }
    }
}