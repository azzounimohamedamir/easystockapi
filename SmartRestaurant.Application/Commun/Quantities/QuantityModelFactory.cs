using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Application.Commun.Quantities
{
    public interface IQuantityModelFactory
    {
        QuantityModel Create(string unitId, decimal value);
        QuantityModel Create(Guid unitId, decimal value);
        QuantityModel Create(Quantity quantity);
    }
    public class QuantityModelFactory : IQuantityModelFactory
    {
        public QuantityModel Create(string unitId, decimal value)
        {
            return new QuantityModel(unitId, value);
        }
        public QuantityModel Create(Guid unitId, decimal value)
        {
            return new QuantityModel(unitId.ToString(), value);
        }

        public QuantityModel Create(Quantity quantity)
        {
            return Create(quantity.UnitId.ToString(), quantity.Value);
        }
    }
}
