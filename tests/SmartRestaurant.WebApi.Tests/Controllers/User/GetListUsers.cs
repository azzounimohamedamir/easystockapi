using SmartRestaurant.WebApi.Tests.Common;
using SmartRestaurant.WebApi.Tests.Controllers.User.ViewModels;
using Xunit;

namespace SmartRestaurant.WebApi.Tests.Controllers.User
{
    public class GetListUsers
    {
        [Fact]
        public async void GetListUsers_WhenNotAuthenticated_ShouldReturnPermissionException()
        {
            var api = new Configuration.WebApi();

            var response = await api.Get<DataList<UserModel>>("/Users");

            Assert.Null(response.Content);
            Assert.Equal(401, response.StatusCode);
        }

        [Fact]
        public async void GetListUsers_WhenNotAuthorized_ShouldReturnPermissionException()
        {
            var api = new Configuration.WebApi();

            await api.Sign("Waiter@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Get<DataList<UserModel>>("/Users");

            Assert.Null(response.Content);
            Assert.Equal(403, response.StatusCode);
        }

        [Fact]
        public async void GetListUsers_WrongPageQueryParameter_ShouldReturnNoData()
        {
            var api = new Configuration.WebApi();

            await api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Get<DataList<UserModel>>("/Users?page=tests");

            Assert.Null(response.Content);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async void GetListUsers_AuthenticatedAndAuthorized_ShouldReturnOK()
        {
            var api = new Configuration.WebApi();

            await api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@");

            var response = await api.Get<DataList<UserModel>>("/Users");

            Assert.NotNull(response.Content);
            Assert.Equal(200, response.StatusCode);
            Assert.True(response.Content.Data.Count >= 1);
        }
    }
}