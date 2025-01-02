using Microsoft.Extensions.Options;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace SmartRestaurant.Infrastructure.Services
{
    public class TranslationApiConfig
    {
        public string ApiKey { get; set; }
        public string Host { get; set; }

    }
    // Define classes to match the structure of the MyMemory API response
    public class MyMemoryTranslationResponse
    {
        public MyMemoryResponseData responseData { get; set; }
    }

    public class MyMemoryResponseData
    {
        public string translatedText { get; set; }
    }

    public class TranslationService : ITranslationService
    {
        readonly TranslationApiConfig _apiConfig;
        
        public TranslationService(IOptions<TranslationApiConfig> conf) 
        { 
            _apiConfig = conf.Value ?? throw new ArgumentNullException(nameof(conf));
        }

        public async Task<string> TranslateAsync(string sourceLanguage, string targetLanguage, string textToTranslate, CancellationToken cancellationToken)
        {
            var _httpClient = new HttpClient();
            try
            {
                string apiUrl = $"https://api.mymemory.translated.net/get?langpair={sourceLanguage}%7C{targetLanguage}&q={Uri.EscapeDataString(textToTranslate)}";

                using var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(apiUrl),
                };

                request.Headers.Add("X-RapidAPI-Key", _apiConfig.ApiKey); // Not required for MyMemory API
                request.Headers.Add("X-RapidAPI-Host", _apiConfig.Host); // Not required for MyMemory API

                using var response = await _httpClient.SendAsync(request, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle non-successful responses
                    throw new HttpRequestException($"Translation API returned non-success status code: {response.StatusCode}");
                }

                var responseBody = await response.Content.ReadAsStringAsync();

                var translationResult = JsonConvert.DeserializeObject<MyMemoryTranslationResponse>(responseBody);

                return translationResult?.responseData?.translatedText;
            }
            catch (Exception exe)
            {
                throw exe;
            }

        }

        
    }
}

