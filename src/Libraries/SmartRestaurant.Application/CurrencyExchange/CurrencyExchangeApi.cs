using Newtonsoft.Json;
using SmartRestaurant.Application.Services;
using System;
using System.Diagnostics;
using System.Net;
namespace SmartRestaurant.Application.CurrencyExchange
{
    public class CurrencyExchangeApi
    {
        private static ConversionRate _conversionRates;
       
        public static void ImportFromOnlineApi()
        {
            ApplicationScheduler.IntervalInHours(DateTime.Now.Hour, DateTime.Now.Minute + 2, 24, Import());
            Action Import()
            {
                return async () =>
                {
                    Debug.WriteLine("Import Currency Exchange");
                    try
                    {
                        string URLString = "https://v6.exchangerate-api.com/v6/954da17c330cec4d33f30d2d/latest/USD";
                        using (var webClient = new WebClient())
                        {
                            var json = await webClient.DownloadStringTaskAsync(URLString).ConfigureAwait(false);
                            var conversionRates = JsonConvert.DeserializeObject<CurrencyConversionRate>(json);
                            if (conversionRates.result == "success")
                            {
                                if (conversionRates.base_code != "USD")
                                    throw new ArgumentException($"The base currency used for currency exchange must be 'USD' not {conversionRates.base_code}");

                                _conversionRates = conversionRates.conversion_rates;
                            }
                            else
                            {
                                throw new Exception($"Currency exchange API call Error => {conversionRates.result}");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine($"Exception 'ImportCurrencyExchangeFromOnlineApi.cs': {e.Message}");
                    }
                };
            }
        }

        public static ConversionRate GetConversionRate()
        {
            return _conversionRates;
        }
    }
}
