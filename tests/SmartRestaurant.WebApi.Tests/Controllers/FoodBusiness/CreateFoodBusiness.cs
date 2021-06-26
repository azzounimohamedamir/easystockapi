using SmartRestaurant.WebApi.Tests.Common;
using Xunit;

namespace SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness
{
    public class CreateFoodBusiness : ProtectedController
    {
        public CreateFoodBusiness() : base("/foodbusiness")
        {
        }

        [Fact]
        public async void GuestTryAccess_ShouldReturnNotAuthenticatedStatus()
        {
            var response = await GetAsGuest();

            Assert.Null(response.Content);
            Assert.Equal(401, response.StatusCode);
        }

        [Fact]
        public async void WaiterTryAccess_ShouldReturnNotAuthorizedStatus()
        {
            var response = await GetAsWaiter();

            Assert.Null(response.Content);
            Assert.Equal(403, response.StatusCode);
        }

        [Fact]
        public async void SupportAgentTryAccess_ShouldReturnOK()
        {
            var response = await GetAsSupportAgent();

            Assert.NotNull(response.Content);
            Assert.Equal(200, response.StatusCode);
        }
    }
}