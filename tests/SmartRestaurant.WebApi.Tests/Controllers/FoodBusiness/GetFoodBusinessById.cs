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
        public void GuestTryAccess_ShouldReturnNotAuthenticatedStatus()
        {
            var response = GetAsGuest();

            Assert.Null(response.Content);
            Assert.Equal(401, response.StatusCode);
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

            Assert.NotNull(response.Content);
            Assert.Equal(200, response.StatusCode);
        }
    }
}