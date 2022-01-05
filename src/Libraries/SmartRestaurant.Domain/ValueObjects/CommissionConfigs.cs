using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Enums;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.ValueObjects
{
    public class CommissionConfigs : ValueObject
    {

        public CommissionConfigs()
        {
            Value = 0;
            Type = CommissionType.PerPerson;
            WhoPay = WhoPayCommission.FoodBusiness;
        }


        public float Value { get; set; }
        public CommissionType Type { get; set; }
        public WhoPayCommission WhoPay { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object>
            {
                Value,
                Type,
                WhoPay
            };
        }
    }
}
