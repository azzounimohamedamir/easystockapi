using SmartRestaurant.WebApi.Tests.Common;
using Xunit;

namespace SmartRestaurant.WebApi.Tests.Controllers.User
{
    public class GetListUsers : ProtectedController
    {
        public GetListUsers() : base("/users")
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

            Assert.NotNull(response.Content);
            Assert.Equal(200, response.StatusCode);
        }
    }
}