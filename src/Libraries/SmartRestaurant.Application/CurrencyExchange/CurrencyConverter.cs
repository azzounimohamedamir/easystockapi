using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Enums;
using System.Collections.Generic;

namespace SmartRestaurant.Application.CurrencyExchange
{
    public class CurrencyConverter
    {
        private static float ToUSD(float price, Currencies currencyCode)
        {          
            var conversionRate = CurrencyExchangeApi.GetConversionRate();
            if (conversionRate == null)
                return 0;

            var exchangeValue = (float) conversionRate.GetType().GetProperty(currencyCode.ToString()).GetValue(conversionRate, null);
            return ((conversionRate.USD * price) / exchangeValue);
        }

        public static float Get(float price, Currencies currentCurrencyCode, Currencies targetCurrencyCode)
        {
            var conversionRate = CurrencyExchangeApi.GetConversionRate();
            if (conversionRate == null)
                return 0;

            if (targetCurrencyCode == Currencies.USD)
                ToUSD(price, currentCurrencyCode);

            var exchangeValue = (float)conversionRate.GetType().GetProperty(targetCurrencyCode.ToString()).GetValue(conversionRate, null);
            return ((exchangeValue * ToUSD(price, currentCurrencyCode)) / conversionRate.USD);
        }

        public static List<CurrencyDto> GetCurrencyExchangeList(float price, Currencies currentCurrencyCode, List<Currencies> targetCurrenciesCodes)
        {
            var currencyExchange = new List<CurrencyDto>()
            {
                new CurrencyDto()
                {
                    MoneyAmount = price,
                    Code = currentCurrencyCode.ToString(),
                    IsDefault = true
                }
            };

           foreach (var targetCurrencyCode in targetCurrenciesCodes)
            {
                currencyExchange.Add(new CurrencyDto()
                {
                    MoneyAmount = Get(price, currentCurrencyCode, targetCurrencyCode),
                    Code = targetCurrencyCode.ToString(),
                    IsDefault = false
                });
            }
            return currencyExchange;
        }

        public static List<CurrencyDto> GetDefaultCurrencyExchangeList(float price, Currencies currentCurrencyCode)
        {
            var targetCurrenciesCodes = new List<Currencies>() { Currencies.USD, Currencies.EUR };

            var currencyExchange = new List<CurrencyDto>()
            {
                new CurrencyDto()
                {
                    MoneyAmount = price,
                    Code = currentCurrencyCode.ToString(),
                    IsDefault = true
                }
            };

            foreach (var targetCurrencyCode in targetCurrenciesCodes)
            {
                currencyExchange.Add(new CurrencyDto()
                {
                    MoneyAmount = Get(price, currentCurrencyCode, targetCurrencyCode),
                    Code = targetCurrencyCode.ToString(),
                    IsDefault = false
                });
            }
            return currencyExchange;
        }

    }
}
