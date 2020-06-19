using System;
using System.Collections.Generic;
using System.Text;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Commun.States.Factory
{
    public interface ICreateStateFactory
    {

        Domain.Commun.State Create(string Name , string IsoCode , 
            string CountryId , string Alias,bool IsDisable); 
    }

    public class CreateStateFactory : ICreateStateFactory
    {
        public Domain.Commun.State Create(string Name, string IsoCode,
            string CountryId , string Alias, bool IsDisabled)
        {
            var entity = new Domain.Commun.State();

            entity.Name = Name;
            entity.IsoCode = IsoCode;
            entity.CountryId = CountryId;
            entity.Alias = Alias;
            entity.IsDisabled = IsDisabled;
            return entity; 
      
        }
    }
}
