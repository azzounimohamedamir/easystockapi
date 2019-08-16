using System.Collections.Generic;

namespace SmartRestaurant.Application.Commun.Countries.Commands.Create
{
    public interface ICreateCountryModel
    {
        string Alias { get; set; }
        List<string> CurrenciesId { get; set; }
        string IsoCode { get; set; }
        string Name { get; set; }
    }
}