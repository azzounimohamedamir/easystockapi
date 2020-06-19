using System.Collections.Generic;

namespace SmartRestaurant.Application.Commun.Countries.Commands.Create
{
    public class CreateCountryModel : ICreateCountryModel
    {

        public string Alias { get; set; }
        public string IsoCode { get; set; }
        public string Name { get; set; }
        public List<string> CurrenciesId { get; set; }
        //public string Token{get;set;}
        public bool IsDisabled { get; set; }
    }
}