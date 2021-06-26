using SmartRestaurant.WebApi.Tests.Common;
using Xunit;

namespace SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness
{
    public class GetFoodBusinessById : ProtectedController
    {
        public GetFoodBusinessById() : base("/foodbusiness/3cbf3570-4444-4673-8746-29b7cf568093")
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