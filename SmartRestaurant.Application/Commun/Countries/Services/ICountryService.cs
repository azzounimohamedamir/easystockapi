using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Commun.Countries.Services
{
    public interface ICountryService
    {
        int Count();
        int Count(ISpecification<Country> specification);
        int Count(string name);
        List<CountryItemModel> List();
        List<CountryItemModel> List(ISpecification<Country> specification);
    }
}