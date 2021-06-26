using SmartRestaurant.WebApi.Tests.Common;
using Xunit;

namespace SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness
{
    public class GetFoodBusinesses : ProtectedController
    {
        public GetFoodBusinesses() : base("/foodbusiness")
        {
        }

        [Fact]
        public void GuestTryAccess_ShouldReturnNotAuthenticatedStatus()
        {
            var response = GetAsGuest();

            Assert.Equal(401, response.StatusCode);
            Assert.Null(response.Content);
        }

        [Fact]
        public void WaiterTryAccess_ShouldReturnNotAuthorizedStatus()
        {
            var response = GetAsWaiter();

            Assert.Equal(403, response.StatusCode);
            Assert.Null(response.Content);
        }

        [Fact]
        public void SupportAgentTryAccess_ShouldReturnOK()
        {
            var response = GetAsSupportAgent();

            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(response.Content);
        }
    }
}