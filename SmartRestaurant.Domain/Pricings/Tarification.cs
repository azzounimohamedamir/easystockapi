using Helpers;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
namespace SmartRestaurant.Domain.Pricings
{
    public class Tarification : BaseEntity<Guid>
    {
        public Tarification()
        {
            ProductTarifications = new List<ProductTarification>();
            DishTarifications = new List<DishTarification>();
        }

        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public decimal Amount { get; set; }
        public bool IsPercentage { get; set; }
        public decimal Percentage => IsPercentage ? Amount / 100m : 0m;
        public string PercentageText => Percentage.FormatDecimal();
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public ICollection<ProductTarification> ProductTarifications { get; set; }
        public ICollection<DishTarification> DishTarifications { get; set; }
    }
}
