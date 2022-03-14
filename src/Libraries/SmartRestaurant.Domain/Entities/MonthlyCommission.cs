using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Domain.Entities
{
    public class MonthlyCommission
    {
        public Guid MonthlyCommissionId { get; set; }
        public float TotalToPay { get; set; }
        public int numberOfOrdersOrPersons { get; set; }
        public DateTime Month { get; set; }
        public CommissionConfigs CommissionConfigs { get; set; }
        public CommissionStatus Status { get; set; }
        public Guid FoodBusinessId { get; set; }       
        public virtual FoodBusiness FoodBusiness { get; set; }
    }
}
