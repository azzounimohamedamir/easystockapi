using System.Threading.Tasks;

namespace SmartRestaurant.WebApi.Tests.Common
{
    public class ProtectedController
    {
        private readonly Api _api;

        protected ProtectedController(string endpoint)
        {
            _api = new Api(endpoint);
        }

        protected async Task<ApiResult<object>> GetAsGuest()
        {
            _api.RemoveAccessToken();
            return await _api.Get<object>();
        }

        protected async Task<ApiResult<object>> GetAsWaiter()
        {
            await _api.Sign("Waiter@SmartRestaurant.io", "Supportagent123@");
            return await _api.Get<object>();
        }

        protected async Task<ApiResult<object>> GetAsSupportAgent()
        {
            await _api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@");
            return await _api.Get<object>();
        }
    }
}