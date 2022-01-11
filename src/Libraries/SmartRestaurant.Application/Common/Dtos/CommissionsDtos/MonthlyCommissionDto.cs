using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;

namespace SmartRestaurant.Application.Common.Dtos.CommissionsDtos
{
    public class MonthlyCommissionDto
    {
        public Guid MonthlyCommissionId { get; set; }
        public float TotalToPay { get; set; }
        public int numberOfOrdersOrPersons { get; set; }
        public DateTime Month { get; set; }
        public CommissionConfigs CommissionConfigs { get; set; }
        public CommissionStatus Status { get; set; }
        public Currencies DefaultCurrency { get; set; }
        public string FoodBusinessName { get; set; }
        public Guid FoodBusinessId { get; set; }
    }
}
