using System;
using System.Collections.Generic;
using System.Text;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Commun.Countries.Factory
{
     public interface ICreateCountryFactory
    {
        Country Create(string Alias, string IsoCode ,
            string Name, bool IsDisabled);
    }

    public class CreateCountryFactory : ICreateCountryFactory
    {
        public Country Create(string Alias, string IsoCode, 
            string Name, bool IsDisabled)
        {
            var entity = new Country();
            entity.Alias = Alias;
            entity.Name = Name;
            entity.IsoCode = IsoCode;
            entity.IsDisabled = IsDisabled;
            return entity; 
        }
    }

   
}
