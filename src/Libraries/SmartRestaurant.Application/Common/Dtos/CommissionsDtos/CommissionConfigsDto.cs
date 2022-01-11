using SmartRestaurant.Domain.Enums;
using System;

namespace SmartRestaurant.Application.Common.Dtos.CommissionsDtos
{
    public class CommissionConfigsDto
    {
        public Guid FoodBusinessId { get; set; }
        public float Value { get; set; }
        public CommissionType Type { get; set; }
        public WhoPayCommission WhoPay { get; set; }
        public Currencies DefaultCurrency { get; set; }
    }
}
