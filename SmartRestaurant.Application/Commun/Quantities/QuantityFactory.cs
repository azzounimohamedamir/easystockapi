using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Commun.Quantities
{
    public interface IQuantityFactory
    {
        Quantity Create(string unitId, decimal value);
    }
    public class QuantityFactory : IQuantityFactory
    {
        public Quantity Create(string unitId, decimal value)
        {
            return new Quantity(unitId.ToGuid(), value);            
        }
    }

    
}
