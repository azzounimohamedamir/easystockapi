using System.Collections.Generic;
using SmartRestaurant.Application.Commun.Countries.Commands.Update;
using SmartRestaurant.Application.Commun.Countries.Queries.GetCountriesList;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;

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