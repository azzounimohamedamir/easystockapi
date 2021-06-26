using SmartRestaurant.WebApi.Tests.ViewModels;

namespace SmartRestaurant.WebApi.Tests.Common
{
    public class ProtectedController
    {
        private readonly string _endpoint;

        protected ProtectedController(string endpoint)
        {
            _endpoint = endpoint;
        }

        protected ApiResult<object> GetAsGuest()
        {
            var api = new Api(_endpoint);
            return api.Get<object>().Result;
        }

        protected ApiResult<object> GetAsWaiter()
        {
            var api = new Api(_endpoint);
            api.Sign("Waiter@SmartRestaurant.io", "Supportagent123@").ConfigureAwait(false);
            return api.Get<object>().Result;
        }

        protected ApiResult<object> GetAsSupportAgent()
        {
            var api = new Api(_endpoint);
            api.Sign("SupportAgent@SmartRestaurant.io", "Supportagent123@").ConfigureAwait(false);
            return api.Get<object>().Result;
        }
    }
}