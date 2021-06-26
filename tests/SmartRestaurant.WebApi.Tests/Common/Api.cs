using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SmartRestaurant.WebApi.Tests.Configuration;
using SmartRestaurant.WebApi.Tests.ViewModels;

namespace SmartRestaurant.WebApi.Tests.Common
{
    public class Api
    {
        private readonly string _endpoint;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _webClient;

        public Api(string endpoint)
        {
            _endpoint = endpoint;
            _webClient = new HttpClient();
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task Sign(string email, string password)
        {
            var response = await PostWithRoute<AuthResponse>("/accounts/login", new
            {
                email, password
            });
            _webClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", response.Content.Token);
        }

        public void RemoveAccessToken()
        {
            _webClient.DefaultRequestHeaders.Clear();
        }

        public async Task<ApiResult<T>> Post<T>(object data) where T : class
        {
            var response = await _webClient.PostAsync($"{AppSettings.GetApiEndpoint()}{_endpoint}", Serialize(data));
            if (response.StatusCode == HttpStatusCode.OK) return await ReturnResponseData<T>(response);
            return ReturnResponseCode<T>(response);
        }

        private async Task<ApiResult<T>> PostWithRoute<T>(string route, object data) where T : class
        {
            var response = await _webClient.PostAsync($"{AppSettings.GetApiEndpoint()}{route}", Serialize(data));
            if (response.StatusCode == HttpStatusCode.OK) return await ReturnResponseData<T>(response);
            return ReturnResponseCode<T>(response);
        }

        public async Task<ApiResult<T>> Get<T>() where T : class
        {
            var response = await _webClient.GetAsync($"{AppSettings.GetApiEndpoint()}{_endpoint}");
            if (response.StatusCode == HttpStatusCode.OK) return await ReturnResponseData<T>(response);
            return ReturnResponseCode<T>(response);
        }

        private static ApiResult<T> ReturnResponseCode<T>(HttpResponseMessage response) where T : class
        {
            return new ApiResult<T>
            {
                StatusCode = (int) response.StatusCode,
                Content = null
            };
        }

        private async Task<ApiResult<T>> ReturnResponseData<T>(HttpResponseMessage response) where T : class
        {
            try
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<T>(json, _options);
                return new ApiResult<T>
                {
                    StatusCode = (int) response.StatusCode,
                    Content = result
                };
            }
            catch
            {
                return ReturnResponseCode<T>(response);
            }
        }

        private static StringContent Serialize(object data)
        {
            var json = JsonSerializer.Serialize(data);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            return httpContent;
        }
    }
}