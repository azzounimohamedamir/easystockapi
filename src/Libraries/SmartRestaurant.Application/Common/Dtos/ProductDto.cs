using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ProductDto
    {    
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public NamesDto Names { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public float Price { get; set; }
        public float EnergeticValue { get; set; }
        public string FoodBusinessId { get; set; }
        public List<CurrencyDto> CurrencyExchange { get; set; }
         public int Quantity { get; set; }
        public bool IsQuantityChecked { get; set; }
        public long OdooId { get; set; }
        public bool SyncFromOdoo { get; set; }
    }
}
