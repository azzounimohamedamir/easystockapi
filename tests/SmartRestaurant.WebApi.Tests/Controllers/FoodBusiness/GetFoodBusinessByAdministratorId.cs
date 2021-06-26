using SmartRestaurant.WebApi.Tests.Common;
using Xunit;

namespace SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness
{
    public class GetFoodBusinessByAdministratorId : ProtectedController
    {
        public GetFoodBusinessByAdministratorId() : base(
            "/foodbusiness/3cbf3570-4444-4444-8746-29b7cf568093/foodBusinessAdministrator")
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

            Assert.Null(response.Content);
            Assert.Equal(403, response.StatusCode);
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