using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Commun.CountryCurrencies.Factory
{
    public  interface ICreateCountryCurrenciesFactory
    {
        CountryCurrency Create(string CountryId, Guid CurrencyId);
    }
    public class CreateCountryCurrenciesFactory : ICreateCountryCurrenciesFactory
    {
        public CountryCurrency Create(string CountryId, Guid CurrencyId)
        {
            CountryCurrency entity = new CountryCurrency();
            entity.CountryId = CountryId;
            entity.CurrencyId = CurrencyId;

            return entity; 
        }
    }
}
