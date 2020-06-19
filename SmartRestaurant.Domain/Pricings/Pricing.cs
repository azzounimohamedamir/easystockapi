using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Pricings
{
    public class Pricing : BaseEntity<Guid>
    {
        public Price PurchasePriceHT { get; set; }
        public Price PurchasePriceTTC => PurchasePriceHT * (1 + Tva / 100m);

        public Price SalePriceHT => PurchasePriceHT + Gain;
        public Price SalePriceTTC => SalePriceHT * (1 + Tva / 100m);

        public Price Gain { get; set; }

        public decimal Tva { get; set; }
        public bool IsPercentage { get; set; }
        public decimal GainAmount { get; set; }

        public Guid? ProductId { get; set; }
        public Guid? DishId { get; set; }

        public Dish Dish { get; set; }
        public Product Product { get; set; }
    }
}
